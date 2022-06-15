using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionareGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(180, 40);
            int help_count = 1;
            int correct_answer_count = 1;
            int right_count = 0;
            int false_count = 0;
            string[] questions = new string[] {
                "What is the capital of Azerbaijan",
                "In the UK, the abbreviation NHS stands for National what Service",
                "Which Disney character famously leaves a glass slipper behind at a royal ball",
                "What name is given to the revolving belt machinery in an airport that delivers checked luggage from the plane to baggage reclaim",
                "Which of these brands was chiefly associated with the manufacture of household locks",
                "The hammer and sickle is one of the most recognisable symbols of which political ideology",
                "Which toys have been marketed with the phrase “robots in disguise”",
                "What does the word loquacious mean",
                "Obstetrics is a branch of medicine particularly concerned with what",
                "Which of these religious observances lasts for the shortest period of time during the calendar year",
            };
            string[][] answers = new string[][]{
               new string[]{"Baku", "Ganja", "Sumgait"},
               new string[]{ "Health", "Humanity", "Honour"},
               new string[]{"Cinderella", "Sleeping Beauty", "Elsa"},
               new string[]{ "Carousel", "Terminal", "Hangar"},
               new string[]{ "Chubb", "Flymo", "Phillips"},
               new string[]{ "Communism", "Republicanism", "Conservatism"},
               new string[]{ "Transformers", "Bratz Dolls", "Sylvanian Families"},
               new string[]{ "Chatty", "Angry", "Shy"},
               new string[]{ "Childbirth", "Heart conditions", "Old age"},
               new string[]{ "Diwali", "Ramadan", "Hanukkah"},
             };
            string[] CorrectAnswers = new string[] {
                "Baku","Health","Cinderella","Carousel","Chubb","Communism","Transformers","Chatty", "Childbirth","Diwali"
            };

            int[] AskedQuestions = new int[0] { };
            Random random = new Random();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Help Count : {help_count}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write($"{right_count * 100 / 10} %");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("   ");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{false_count * 100 / 10} %");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (correct_answer_count == 0) break;
                int num = random.Next(0, 10);
                if (Array.IndexOf(AskedQuestions, num) == -1)
                {
                    AskedQuestions = AdditemToArray(AskedQuestions, num);
                    var CurrentQuestion = questions[num];
                    var CurrentCorrectAnswer = CorrectAnswers[num];
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{CurrentQuestion} ? ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    string[] CurrentAnswers = answers[num];
                    int[] UsedIndexes = new int[0];
                    while (true)
                    {
                        int number = random.Next(0, 3);
                        if (Array.IndexOf(UsedIndexes, number) == -1)
                        {
                            UsedIndexes = AdditemToArray(UsedIndexes, number);
                        }
                        else
                        {
                            if (UsedIndexes.Length == 3) break;
                        }
                    }
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"A){CurrentAnswers[UsedIndexes[0]]}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"B){CurrentAnswers[UsedIndexes[1]]}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"C){CurrentAnswers[UsedIndexes[2]]}");
                    Console.BackgroundColor = ConsoleColor.Black;

                    bool IsChar = char.TryParse(Console.ReadLine(), out char ans);
                    if (IsChar)
                    {
                        if (ans == 'A' || ans == 'a')
                        {
                            if (CurrentAnswers[UsedIndexes[0]] == CurrentCorrectAnswer)
                            {
                                correct_answer_count++;
                                right_count++;
                            }
                            else
                            {
                                correct_answer_count--;
                                false_count++;
                            }

                        }
                        else if (ans == 'B' || ans == 'b')
                        {
                            if (CurrentAnswers[UsedIndexes[1]] == CurrentCorrectAnswer)
                            {
                                correct_answer_count++;
                                right_count++;
                            }
                            else
                            {
                                correct_answer_count--;
                                false_count++;
                            }
                        }
                        else if (ans == 'C' || ans == 'c')
                        {
                            if (CurrentAnswers[UsedIndexes[2]] == CurrentCorrectAnswer)
                            {
                                correct_answer_count++;
                                right_count++;
                            }
                            else
                            {
                                correct_answer_count--;
                                false_count++;
                            }
                        }
                        else if (ans == 'H' || ans == 'h')
                        {
                            if (help_count == 1)
                            {
                                correct_answer_count++;
                                right_count++;
                                help_count--;
                            }
                            else
                            {
                                correct_answer_count--;
                                false_count++;
                            }
                        }
                        else correct_answer_count--;
                    }
                }
                else
                {
                    if (AskedQuestions.Length == questions.Length) break;
                }
            }
            Console.Clear();
            int result_percent = correct_answer_count * 100 / 10;
            if(result_percent == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Thank you for your participation. We hope to see you again.");
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (result_percent < 30)
            {
                ShowResultPage(500);
            }
            else if (result_percent < 50)
            {
                ShowResultPage(5000);
            }
            else if (result_percent < 70)
            {
                ShowResultPage(30000);
            }
            else if(result_percent<100)
            {
                ShowResultPage(100000);
            }
            else
            {
                    ShowResultPage(1000000);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void ShowResultPage(int earn)
        {
            for (int i = 0; i < 15; i++)
            {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(70, 18);
            Console.WriteLine($"Thank you for your participation. You earn {earn}$ from us.");
            Thread.Sleep(500);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(70, 18);
            Console.WriteLine($"Thank you for your participation. You earn {earn}$ from us.");
            Thread.Sleep(500);
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static int[] AdditemToArray(int[] array, int num)
        {
            int[] destination = new int[array.Length + 1];
            Array.Copy(array, 0, destination, 0, array.Length);
            destination[array.Length] = num;
            return destination;
        }
    }
}
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                int counter;
                double score;
    
                while (true)
                {
                    counter = 1;
                    score = 0.0;
                    Console.WriteLine("Name(type 'Exit' to quit): ");
                    string sname = Console.ReadLine();
                    if (sname == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        int numberOfQuizzes = 0;
                        Console.WriteLine("Number of Quizzes:  ");
                        numberOfQuizzes = int.Parse(Console.ReadLine());
    
                        while (counter <= numberOfQuizzes)
                        {
                        Console.WriteLine("Quiz Score {0}", counter);
                        score += double.Parse(Console.ReadLine());
                        counter++;
                        }
                        score = (score/(counter-1));
                        if (score < 60)
                        {
                            Console.WriteLine("Letter Grade: F");
                        }
                        else if (60 <= score && score < 70)
                        {
                            Console.WriteLine("Letter Grade: D");
                        }
                        else if (70 <= score && score < 80)
                        {
                            Console.WriteLine("Letter Grade: C");
                        }
                        else if (80 <= score && score < 90)
                        {
                            Console.WriteLine("Letter Grade: B");
                        }
                        else if (90 <= score)
                        {
                            Console.WriteLine("Letter Grade: A");
                        }
                        
                        Console.WriteLine("Grade: {0}",(score/100).ToString("P"));
                    }
                }
            }
        }
    }

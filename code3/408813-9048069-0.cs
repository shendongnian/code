    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string userIsFinished = "";
                string name, city;
                double rating, avg = 0;
                double max = 0;
                double min = 10;
                double score, value = 0, totalScore = 0, finalScore = 0;
                
    
                //get basic information
                do
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Please enter divers name.");
                    name = Console.ReadLine();
                    Console.WriteLine("Please enter the divers city.");
                    city = Console.ReadLine();
    
    
    
                    //get and validate user input for 1 dive rating
                    Console.WriteLine("Please enter a dive rating between 1.00 and 1.67.");
                    rating = Double.Parse(Console.ReadLine());
                    while (rating < 1 || rating > 1.69)
                    {
                        Console.WriteLine("Oops, you entered an invalid number. Please, enter a dive rating between 1.00 and 1.67.");
                        rating = Double.Parse(Console.ReadLine());
                    }
                    Console.ReadLine();
                    
                    // get and validate user input for 5 judge scores
                    for (int s = 1; s <= 5; s++)
                    {
                        Console.WriteLine("Please enter the score for judge {0}.", s);
                        score = Convert.ToDouble(Console.ReadLine());
                        
                        while (score < 0 || score > 10)
                        {
                            Console.WriteLine("Invalid entry, please enter a number in between 0 - 10.");
                            score = Convert.ToDouble(Console.ReadLine());
                        }
                        if (score > max)
                            max = score;
                        if (score < min)
                            min = score;
    
                        totalScore = score + totalScore;
                    }
                    Console.ReadLine();
                    \\Calculate values
                    value = totalScore - max - min;
                    avg = value / 3;
                    finalScore = avg * rating;
    
                    //Print gathered and calculated information
                    Console.WriteLine("Divers name: {0}", name);
                    Console.WriteLine("Divers city: {0}", city);
                    Console.WriteLine("Dive degree of difficulty: {0}", rating);
                    Console.WriteLine("Total dive score is: {0}", finalScore);
                    Console.WriteLine("\n");
                    
                    // Ask if user wants to process another diver and continue or exit program
                    Console.WriteLine("Would you like to enter another divers information? [Y]es [N]o: ");
                    userIsFinished = Console.ReadLine();
                }
                while
                (userIsFinished.ToLower() != "n");
                Console.ReadLine();
                Console.WriteLine("\n");
            }
        }
    }

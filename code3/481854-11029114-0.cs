    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            int[] counterArray = new int[123];
            string myString;
            int wordCounted = 0;
            int result = 0;
            //Prompt user and get value
            myString = getStringMethod();
            //Word count
            wordCounted = countWordsMethod(myString, wordCounted);
            //White space count
            result = spaceCounterMethod(myString, result);
            //Display words and space count,
            displayCountMethod(counterArray, myString, wordCounted, result);
            //Display uppercase letter count
            displayUpperMethod();
            //Counting uppercase letter
            uppserCaseMethod(counterArray);
            //Display lowercase letter count
            displayLowerMethod();
            //Counting lowercase letter
            lowerCaseMethod(counterArray);
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
        private static void displayLowerMethod()
        {
            Console.WriteLine("LOWERCASE LETTERS: ");
        }
        private static void displayUpperMethod()
        {
            Console.WriteLine("\nUPPERCASE LETTERS: ");
        }
        private static void lowerCaseMethod(int[] counterArray)
        {
            for (int z = 97; z < 123; z++)
            {
                if (counterArray[z] > 0)
                {
                    Console.WriteLine("\t\t{0}:  \t{1}", Convert.ToChar(z),         counterArray[z]);
                }
            }
        }
        private static void upp

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    namespace ReadLine
    {
    class Program
    {
        static void Main(string[] args)
        {
            //Load our text file
            TextReader tr = new StreamReader("\\test.txt");
            //How many lines should be loaded?
            int NumberOfLines = 15;
            //Make our array for each line
            string[] ListLines = new string[NumberOfLines];
            //Read the number of lines and put them in the array
            for (int i = 1; i < NumberOfLines; i++)
            {
                ListLines[i] = tr.ReadLine();
            }
            //This will write the 5th line into the console
            Console.WriteLine(ListLines[5]);
            //This will write the 1st line into the console
            Console.WriteLine(ListLines[1]);
            Console.ReadLine();
            // close the stream
            tr.Close();
        }
    }
    }

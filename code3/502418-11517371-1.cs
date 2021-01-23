    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.IO;
    using System.Xml.Linq;
    using System.Diagnostics;
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int[]> arrays = new List<int[]>();
                int counter = 0;
                string line;
                // Read the file
                System.IO.StreamReader file =
                   new System.IO.StreamReader("c:\\temp\\test.txt");
                while ((line = file.ReadLine()) != null)
                {
                    // split the line into a string array on , separator
                    string[] splitLine = line.ToString().Split(',');
                    // if our split isnt null and has a positive length
                    if (splitLine != null && splitLine.Length > 0)
                    {
                        // create a lineArray the same size as our new string[]
                        int[] lineArray = new int[splitLine.Length];
                        int posCounter = 0;
                        foreach (string splitValue in splitLine)
                        {
                            // loop through each value in the split, try and convert
                            // it into an int and push it into the array
                            try
                            {
                                lineArray[posCounter] = Int32.Parse(splitValue);
                            }
                            catch { }
                            posCounter++;
                        }
                        // if our lineArray has a positive length then at it to our
                        // list of arrays for processing later.
                        if (lineArray.Length > 0)
                        {
                            arrays.Add(lineArray);
                        }
                    }
                    counter++;
                }
                file.Close();
                // go through the List<int[]> and print to screen
                foreach (int[] row in arrays)
                {
                    foreach (int rowCol in row)
                    {
                        Console.Write(rowCol + ",");
                    }
                    Console.WriteLine();
                }
                // Suspend the screen.
                Console.ReadLine();
            }
        }
    }

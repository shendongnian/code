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
                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader("c:\\temp\\test.txt");
                while ((line = file.ReadLine()) != null)
                {
                    string[] splitLine = line.ToString().Split(',');
                    if (splitLine != null && splitLine.Length > 0)
                    {
                        int[] lineArray = new int[splitLine.Length];
                        int posCounter = 0;
                        foreach (string splitValue in splitLine)
                        {
                            try
                            {
                                lineArray[posCounter] = Int32.Parse(splitValue);
                            }
                            catch { }
                            posCounter++;
                        }
                        if (lineArray.Length > 0)
                        {
                            arrays.Add(lineArray);
                        }
                    }
                    counter++;
                }
                file.Close();
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

    // I have used framework 4  
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static int Compare(KeyValuePair<string, int> kv1, KeyValuePair<string, int> kv2)
        {
            return kv2.Value.CompareTo(kv1.Value);   // descending order
        }
        public static void Main()
        {
            try
            {
                int linecount = 0;
                Dictionary<string, int> histogram = new Dictionary<string, int>();      // creates a dictionary from the text file
                using (StreamReader reader = new StreamReader("tweets.txt"))        //reads the text file specified
                {
                    string difline;
                    while ((difline = reader.ReadLine()) != null)       //continues until no lines left
                    {                   
                        linecount++;    //increases the count
                        if (histogram.ContainsKey(difline))     //counts specific strings
                            ++histogram[difline];
                        else
                            histogram.Add(difline, 1);
                    }
                }
                Console.WriteLine("Line count: " + linecount);
                Console.WriteLine("Top 20:");
                List<KeyValuePair<string, int>> sortedHistogram = new List<KeyValuePair<string, int>>(histogram);
                sortedHistogram.Sort(Compare);
                foreach (KeyValuePair<string, int> kv in sortedHistogram.Take(20))
                    Console.WriteLine("{0}\t{1}", kv.Value, kv.Key);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:"); // Let the user know what went wrong.
                Console.WriteLine(e.Message);
            }
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
        }
    }

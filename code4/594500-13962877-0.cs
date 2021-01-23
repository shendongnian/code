    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var startIndex = 1000000; // 00:00:00.0004876
                //var startIndex = 1;     // 00:00:00.0152319
                var searchedKey = "1";
                OrderedDictionary orderedDictionary = new OrderedDictionary();
                //populate
                for (int i = 2; i < 1000002; i++)
                {
                    orderedDictionary.Add(i.ToString(), "X");
                }
                orderedDictionary.Add("1", "A");
                //copy the keys
                String[] keys = new String[1000006];
                orderedDictionary.Keys.CopyTo(keys, 0);
                //measure the time with a System.Diagnostics.StopWatch
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = startIndex; i < orderedDictionary.Count; i++)
                {
                    if (keys[i] == searchedKey)
                    {
                        Console.WriteLine(orderedDictionary[i]);
                        break;
                    }
                }
                watch.Stop();
                Console.WriteLine(watch.Elapsed);
            }
        }
    }

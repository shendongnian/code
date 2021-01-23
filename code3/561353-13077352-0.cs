    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackOverflow.Demos
    {
        class Program
        {
            const string OutputFormat = "{0}: {1}";
            public static void Main(string[] args)
            {
                new Program();
                Console.WriteLine("Done");
                Console.ReadKey();
            }
            public Program()
            {
                SortedDictionary<string, int> dic = new SortedDictionary<string, int>();
                dic.Add("a", 1);
                dic.Add("b", 2);
                dic.Add("d", 2);
                dic.Add("c", 1);
                dic.Add("e", 1);
                dic.Add("f", 3);
                dic.Add("g", 4);
                dic.Add("h", 2);
                dic.Add("i", 2);
                OutputByKeyAsc(dic);
                OutputByKeyDesc(dic);
                OutputByValueFrequency(dic);
            }
            void OutputByKeyAsc(SortedDictionary<string, int> dic)
            {
                Console.WriteLine("OutputByKeyAsc");
                foreach (string key in dic.Keys)
                {
                    Console.WriteLine(string.Format(OutputFormat, key, dic[key]));
                }
            }
            void OutputByKeyDesc(SortedDictionary<string, int> dic)
            {
                Console.WriteLine("OutputByKeyDesc");
                foreach (string key in dic.Keys.Reverse())
                {
                    Console.WriteLine(string.Format(OutputFormat, key, dic[key]));
                }
            }
            void OutputByValueFrequency(SortedDictionary<string, int> dic)
            {
                Console.WriteLine("OutputByValueFrequency");
            
                IEnumerable<KeyValuePair<int,int>> values = 
                    (
                        from sortedItem 
                        in 
                        (
                            from entry 
                            in dic 
                            group entry 
                            by entry.Value
                            into result
                            select new KeyValuePair<int,int>(result.Key , result.Count())
                        )
                        orderby sortedItem.Value descending
                        select sortedItem
                    ).ToArray();
                foreach (KeyValuePair<int, int> value in values)
                {
                    foreach (KeyValuePair<string, int> item in dic.Where<KeyValuePair<string, int>>(item => item.Value == value.Key))
                    {
                        Console.WriteLine(string.Format(OutputFormat, item.Key, string.Format(OutputFormat, item.Value, value.Value)));
                    }
                }
            }
        }
    }

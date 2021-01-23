    using System;
    using System.Collections.Generic;
    namespace SO14715593
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, List<KeyValuePair<string, string>>> variants = new Dictionary<string, List<KeyValuePair<string, string>>>();
                variants["test"] = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("key1", "item1"),
                        new KeyValuePair<string, string>("key2", "item2"),
                        new KeyValuePair<string, string>("key3", "item3")
                    };
                Random random = new Random();
                int index = random.Next(3);
                Console.WriteLine("{0};{1}", variants["test"][index].Key, variants["test"][index].Value);
            }
        }
    }

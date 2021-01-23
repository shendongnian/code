    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                File.WriteAllText("sample1.txt", "The things God has prepared for those who love him the");
                string text = File.ReadAllText("sample1.txt").ToLower();
                var words = text
                    .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .OrderByDescending(word => word.Length);
                var values = new Dictionary<string, int>();
                for (int i = 0; i < words.Count(); i++)
                {
                    values.Add(words.ElementAt(i), i + 1);
                }
                foreach (var kvp in values)
                {
                    text = text.Replace(kvp.Key, kvp.Value.ToString());
                }
                File.WriteAllText("sample1.txt", text);
                Console.WriteLine("Press ENTER to exit");
                Console.ReadLine();
            }
        }
    }

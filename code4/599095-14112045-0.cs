    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        internal class Program
        {
            private static void Main()
            {
                var input = new[] {"This is TEST TEST string", "shift+shift+shift+D"};
                foreach (string data in input)
                {
                    bool contains = data.Contains((char)0x20);
                    Console.WriteLine(contains ? StripFromSentence(data.TrimEnd(new[] {(char) 0x20})) : StripFromWord(data));
                }
                Console.ReadLine();
            }
    
            private static string StripFromWord(string word)
            {
                char[] chr = word.ToCharArray();
                var ap = new HashSet<char>();
                foreach (char s in chr)
                    ap.Add(s);
                return ap.Aggregate(string.Empty, (current, c) => current + c);
            }
    
            private static string StripFromSentence(string sentence)
            {
                string[] strings = sentence.Split(new[] {(char) 0x20});
                var ap = new HashSet<string>();
                foreach (string s in strings)
                    ap.Add(s);
                return ap.Aggregate(string.Empty, (current, word) => current + (word + (char)0x20));
            }
        }
    }

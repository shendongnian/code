    using System;
    using System.Linq;
    
    namespace SplitProblem
    {
        public static class StringAndCharExtensions
        {
            const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public static bool IsUpper(this string theChar)
            {
                return theChar.ToUpper() == theChar;
            }
            public static string TransformLinqExample(this string toTransform)
            {
                string answer = toTransform
                    .ToCharArray()
                    .Select(c => new string(c, 1))
                    .Aggregate((a, c) => a += (CapitalLetters.Contains(c) && c.IsUpper() && !a.EndsWith("-") && !a.EndsWith(" ")) ? " " + c : "" + c);
                return answer;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string toSplit = "Ultra12.4 34.2 Corrosion-ResistantCoated 18-6 AlloySteel";
                string tranformed = toSplit.TransformLinqExample();
                Console.WriteLine("{0}\n\n", tranformed);
    
                foreach (var part in tranformed.Split(' '))
                {
                    Console.WriteLine(part);
                }
                Console.ReadLine();
            }
        }
    }

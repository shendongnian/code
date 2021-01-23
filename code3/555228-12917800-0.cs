    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    
    namespace Test
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                const string target = "abbbdbsdbsbbdbsabdbsabaababababafhdfhffadfd";
                
                // Jit methods
                TimeMethod(FoundIndexesLoop, target, 1);
                TimeMethod(FoundIndexesIndexOf, target, 1);            
                
                Console.WriteLine("Found by loop, {0} ms", TimeMethod(FoundIndexesLoop, target, 2000000));
                Console.WriteLine("Found by IndexOf {0} ms", TimeMethod(FoundIndexesIndexOf, target, 2000000));           
            }
            
            private static long TimeMethod(Func<string, List<int>> method, string input, int reps)
            {
                var stopwatch = Stopwatch.StartNew();
                List<int> result = null;
                for(int i = 0; i < reps; i++)
                {
                    result = method(input);
                }
                stopwatch.Stop();
                TextWriter.Null.Write(result);
                return stopwatch.ElapsedMilliseconds;
            }
            
            private static List<int> FoundIndexesIndexOf(string s)
            {
                List<int> indexes = new List<int>();
                            
                for (int i = s.IndexOf('a'); i > -1; i = s.IndexOf('a', i + 1))
                {
                     // for loop end when i=-1 ('a' not found)
                    indexes.Add(i);
                }
                
                return indexes;
            }
            
            private static List<int> FoundIndexesLoop(string s)
            {
                var indexes = new List<int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'a')
                    indexes.Add(i);
                }
                
                return indexes;
            }
        }
    }

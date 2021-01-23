    using System;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test1 = "A really big string that has more than 140 chars. This string is supposed to be trunctaded by the Truncate extension method defined in class StringTool.";
    
                Console.WriteLine(test1.Truncate(140));
    
                Console.ReadLine();
            }
        }
    
        /// <summary>
        /// Custom string utility methods.
        /// </summary>
        public static class StringTool
        {
            /// <summary>
            /// Get a substring of the first N characters.
            /// </summary>
            public static string Truncate(this string source, int length)
            {
                if (source.Length > length)
                {
                    source = source.Substring(0, length);
                }
                return source;
            }
    
            /// <summary>
            /// Get a substring of the first N characters. [Slow]
            /// </summary>
            public static string Truncate2(this string source, int length)
            {
                return source.Substring(0, Math.Min(length, source.Length));
            }
        }
    }

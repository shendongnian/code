    using System;
    namespace Demo
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("123456789".Left(5));
                Console.WriteLine("123456789".Left(15));
            }
        }
        public static class StringExt
        {
            public static string Left(this string @this, int count)
            {
                if (@this.Length <= count)
                {
                    return @this;
                }
                else
                {
                    return @this.Substring(0, count);
                }
            }
        }
    }

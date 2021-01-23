    using System;
 
    public class Test
    {
        public static void Main()
        {
            var a = new[] { "s" }; 
            var b = new[] { 1 }; 
            Console.WriteLine(IsStringArray(a));
            Console.WriteLine(IsStringArray(b));
        }
        static bool IsStringArray<T>(T[] t)
        {
            return typeof(T) == typeof(string);
        }
    }
    

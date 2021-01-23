    using System;
    using System.Reflection;
    
    delegate string ConvertsIntToString(int i);
    
    class Program
    {
        static void Main(string[] args)
        {
            // Obviously this can come from elsewhere
            string name = "HiThere";
            
            var method = typeof(Program).GetMethod(name, 
                                                   BindingFlags.Static | 
                                                   BindingFlags.NonPublic);
            var del = (ConvertsIntToString) Delegate.CreateDelegate
                (typeof(ConvertsIntToString), method);
            
            string result = del(5);
            Console.WriteLine(result);
        }
    
        private static string HiThere(int i)
        {
            return "Hi there! #" + (i * 100);
        }
     }

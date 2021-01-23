    using System;
    
    namespace Programs
    {
        public class Program
        {      
            public static void Main(string[] args)
            {
                Go(5);
            }
    
            static void Go(int a, bool isFalse = true)
            {
                Console.WriteLine("Int is {0}, Boolean is {1}", a, isFalse);
            }
        }
    }

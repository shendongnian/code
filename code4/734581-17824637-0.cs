    sing System;
    
    class Runner
    {
        static void Main()
        {
            A a = new A();
            a.PrintStuff();
            Console.Read();
        }
    }
    
    class A { }
    
    static class AExtensions
    {
        public static void PrintStuff(this A a)
        {
            Console.WriteLine("text");
        }
    }

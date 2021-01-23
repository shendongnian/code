    using System;
    
    class Program {
        static void Main(string[] args) {
            Foo.Bar(0);
            Console.ReadLine();
        }
    }
    
    class Foo {
        public static void Bar(byte arg)  { Console.WriteLine("byte overload"); }
        public static void Bar(short arg) { Console.WriteLine("short overload"); }
        public static void Bar(long arg)  { Console.WriteLine("long overload"); }
    }

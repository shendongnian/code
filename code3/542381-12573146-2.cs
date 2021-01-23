    using System;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Marshal.SizeOf(typeof(Example)));
            Console.ReadLine();
        }
    }
    struct Example {
        public int a;
        public short b;
    }

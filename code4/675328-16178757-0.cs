    using System;
    using System.Diagnostics;
    class Program {
        static void Main() {
            WriteLine("Hello");
            WriteLine("The number is {0}", 42);
        }
        static void WriteLine(string format, params object[] args) {
            string message = String.Format(format, args);
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }
    }

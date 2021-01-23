    using System;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string text = "My name is Archit Patel";
            Console.WriteLine(string.Join(" ", text.Split(' ').Reverse()));
        }
    }

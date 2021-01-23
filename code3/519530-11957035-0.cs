    using System;
    using System.Linq;
    public class Program
    {
        static void Main()
        {
            var list = new[] { "Dad", "mam", "Junior", "Richard" }.ToList();
            list.RemoveAt(2);
            Console.WriteLine(list[2]);
        }
    }

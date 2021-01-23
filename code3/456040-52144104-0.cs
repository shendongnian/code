        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.IO;
        namespace ConsoleApplication1
        {
         class Program
        {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("E:\\Exp2Act1.txt");
             
            int what1 = (Console.WindowWidth / 2) - 18;
            int here1 = (Console.WindowHeight / 3);
            Console.SetCursorPosition(what1, here1);
            Console.WriteLine(lines[0]);
            int what2 = (Console.WindowWidth / 2) - 18;
            int here2 = (Console.WindowHeight / 3) + 1;
            Console.SetCursorPosition(what2, here2);
            Console.WriteLine(lines[1]);
            int what3 = (Console.WindowWidth / 2) - 18;
            int here3 = (Console.WindowHeight / 3) + 2;
            Console.SetCursorPosition(what3, here3);
            Console.WriteLine(lines[2]);
            int what4 = (Console.WindowWidth / 2) - 18;
            int here4 = (Console.WindowHeight / 3) + 3;
            Console.SetCursorPosition(what4, here4);
            Console.WriteLine(lines[3]);
            int what5 = (Console.WindowWidth / 2) - 18;
            int here5 = (Console.WindowHeight / 3) + 4;
            Console.SetCursorPosition(what5, here5);
            Console.WriteLine(lines[4]);
            int what6 = (Console.WindowWidth / 2) - 18;
            int here6 = (Console.WindowHeight / 3) + 5;
            Console.SetCursorPosition(what6, here6);
            Console.WriteLine(lines[5]);
            Console.Read();
        }
    }
}

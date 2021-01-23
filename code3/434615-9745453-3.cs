    using System;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
             static Random random = new Random();
             static int max_X = Console.WindowWidth; 
             static int max_Y = Console.WindowHeight;
    
             static void Main(string[] args)
             {
                 while (true)
                 {
                     int x = random.Next(max_X);
                     int y = random.Next(max_Y);
                     Console.Clear();
                     Console.SetCursorPosition(x, y);
                     Console.Write("walaa");
                     Thread.Sleep(500);
                     while (Console.KeyAvailable)
                     {
                         ConsoleKeyInfo cki = Console.ReadKey();
                         if (cki.Key == ConsoleKey.Escape)
                         {
                             return;
                         }
                     }
                 }
             }
        }
    }

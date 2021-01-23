    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
             static Random random = new Random();
             static int max_X = Console.WindowWidth; 
             static int max_Y = Console.WindowHeight;
    
             static void Main(string[] args)
             {
                 int x = random.Next(max_X);
                 int y = random.Next(max_Y);
                 Console.SetCursorPosition(x, y);
                 Console.Write("walaa");
                 Console.ReadLine();//keep console open so you can see output
             }
        }
    }

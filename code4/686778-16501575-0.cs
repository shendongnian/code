    class Program
    {
        static void Main(string[] args)
        {
            const int delay = 100;
            DateTime nextMove = DateTime.Now.AddMilliseconds(delay);
            bool quit = false;
            bool gameOver = false;
            while (!quit && !gameOver)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true); // read key without displaying it
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            Console.Write("L");
                            break;
                        case ConsoleKey.RightArrow:
                            Console.Write("R");
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                    }
                }
                if (!quit && !gameOver && DateTime.Now > nextMove)
                {
                    // ... move the pieces ...
                    Console.Write(".");
                    nextMove = DateTime.Now.AddMilliseconds(delay);
                }
                System.Threading.Thread.Sleep(50);
            }
        }
    }

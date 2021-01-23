    using System;
    using System.Threading;
    class TestLoops
    {
        static int targetFPS = 5;
        static bool CONTINUE = true;
        public static void Main(string[] args)
        {
            long _current = 0;
            long _last = 0;
            while (CONTINUE)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Q)
                    {
                        Console.WriteLine("\n'Q' was pressed.");
                        CONTINUE = false;
                    }
                    if (cki.Key == ConsoleKey.P)
                    {
                        Console.WriteLine("\n'P' was pressed; press 'R' to resume.");
                        // Block until 'R' is pressed.
                        while (Console.ReadKey(true).Key != ConsoleKey.R)
                            ;
                        Console.WriteLine("\n'P' was pressed; press 'R' to resume.");
                    }
                }
                _current = DateTime.Now.Ticks / 1000;
                if (_current > _last + (1000 / targetFPS))
                {
                    _last = _current;
                    //Do something...
                    Console.Write(".");
                }
                else
                {
                    System.Threading.Thread.Sleep(10);
                }
            }        
        }
    }

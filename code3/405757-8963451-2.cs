    using System;
    using System.Threading;
    class TestLoops
    {
        const int targetFPS = 5;
        public static void Main(string[] args)
        {
            bool _continue = true;
            DateTime _last = DateTime.MinValue;
            while (_continue)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Q)
                    {
                        Console.WriteLine("\n'Q' was pressed.");
                        _continue = false;
                    }
                    if (cki.Key == ConsoleKey.P)
                    {
                        Console.WriteLine("\n'P' was pressed; press 'R' to resume.");
                        // Block until 'R' is pressed.
                        while (Console.ReadKey(true).Key != ConsoleKey.R)
                            ; // Do nothing.
                        Console.WriteLine("'R' was pressed.");
                    }
                }
                DateTime _current = DateTime.Now;
                if (_current - _last > TimeSpan.FromMilliseconds(1000F / targetFPS))
                {
                    _last = _current;
                    // Do something...
                    Console.Write(".");
                }
                else
                {
                    System.Threading.Thread.Sleep(10);
                }
            }        
        }
    }

    class Program
    {
        private static ConsoleColor _userColor;
        static void Main(string[] args)
        {
            var myKey = Console.ReadKey(true);
            switch (myKey.Key)
            {
                case ConsoleKey.F1:
                    _userColor = ConsoleColor.Green;
                    break;
                case ConsoleKey.F2:
                    _userColor = ConsoleColor.Cyan;
                    break;
                case ConsoleKey.F3:
                    _userColor = ConsoleColor.Red;
                    break;
                case ConsoleKey.F4:
                    _userColor = ConsoleColor.Magenta;
                    break;
                case ConsoleKey.F5:
                    _userColor = ConsoleColor.Blue;
                    break;
                case ConsoleKey.F6:
                    _userColor = ConsoleColor.Yellow;
                    break;
            }
            DoSomething();
            Console.ReadLine();
        }
        private static void DoSomething()
        {
            Console.ForegroundColor = _userColor;
            Console.WriteLine("color choosen");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = _userColor;
            Console.WriteLine("flipped it");
        }
    }

    public static class Console2
    {
        private static bool _isReading;
        private static string _currentPrefix;
        private static readonly StringBuilder CurrentReadLine = new StringBuilder();
        public static string ReadLine(string prefix = null)
        {
            _currentPrefix = prefix;
            _isReading = true;
            Console.Write(prefix);
            while (true)
            {
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Escape)
                {
                    CurrentReadLine.Clear();
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    if (CurrentReadLine.Length > 0)
                    {
                        CurrentReadLine.Length--;
                    }
                    ClearConsole();
                    Console.Write(prefix + CurrentReadLine);
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    var result = CurrentReadLine.ToString();
                    CurrentReadLine.Clear();
                    _isReading = false;
                    return result;
                }
                else
                {
                    CurrentReadLine.Append(cki.KeyChar);
                }
            }
        }
        static void ClearConsole()
        {
            var length = Console.CursorLeft;
            Console.CursorLeft = 0;
            for (int i = 0; i <= length; i++)
            {
                Console.Write(" ");
            }
            Console.CursorLeft = 0;
        }
        public static void WriteLine(string format, params object[] args)
        {
            ClearConsole();
            Console.WriteLine(format, args);
            if (_isReading)
            {
                Console.Write(_currentPrefix + CurrentReadLine);
            }
        }
    }

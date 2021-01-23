        static void Main()
        {
            for (int i = 0; i < 40; i++)
            {
                var str = Convert.ToString(i, 2);
                var bitCount = str.Count(c => c == '1');
                Console.ForegroundColor = bitCount == 1 ? ConsoleColor.White : ConsoleColor.DarkGray;
                Console.WriteLine(i + ": " + (bitCount == 1));
            }
        }

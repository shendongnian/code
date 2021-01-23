        static string ReadString() {
            var buf = new StringBuilder();
            for (; ; ) {
                while (!Console.KeyAvailable) System.Threading.Thread.Sleep(31);
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) {
                    Console.WriteLine();
                    return buf.ToString();
                }
                else if (key.Key == ConsoleKey.Backspace) {
                    if (buf.Length > 0) {
                        buf.Remove(buf.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else {
                    buf.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
        }

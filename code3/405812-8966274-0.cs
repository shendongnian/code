    private static string EmulateReadLine()
    {
        StringBuilder sb = new StringBuilder();
        int pos = 0;
        Action<int> SetPosition = (i) =>
            {
                i = Math.Max(0, Math.Min(sb.Length, i));
                pos = i;
                Console.CursorLeft = i;
            };
        Action<char, int> SetLastCharacter = (c, offset) =>
            {
                Console.CursorLeft = sb.Length + offset;
                Console.Write(c);
                Console.CursorLeft = pos;
            };
        ConsoleKeyInfo key;
        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            int length = sb.Length;
            if (key.Key == ConsoleKey.LeftArrow)
            {
                SetPosition(pos - 1);
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                SetPosition(pos + 1);
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                if (pos == 0) continue;
                sb.Remove(pos - 1, 1);
                SetPosition(pos - 1);
            }
            else if (key.Key == ConsoleKey.Delete)
            {
                if (pos == sb.Length) continue;
                sb.Remove(pos, 1);
            }
            else if (key.Key == ConsoleKey.Home)
                SetPosition(0);
            else if (key.Key == ConsoleKey.End)
                SetPosition(int.MaxValue);
            else if (key.Key == ConsoleKey.Escape)
            {
                SetPosition(0);
                sb.Clear();
            }
            // CUSTOM LOGIC FOR CTRL+A
            else if (key.Key == ConsoleKey.A &&
                (key.Modifiers & ConsoleModifiers.Control) != 0)
            {
                string stringtoinsert = "^";
                sb.Insert(pos, stringtoinsert);
                SetPosition(pos + stringtoinsert.Length);
            }
            else if (key.KeyChar != '\u0000') // keys that input text
            {
                sb.Insert(pos, key.KeyChar);
                SetPosition(pos + 1);
            }
            // replace entire line with value of current input string
            Console.CursorLeft = 0;
            Console.Write(sb.ToString());
            Console.Write(new string(' ', Math.Max(0, length - sb.Length)));
            Console.CursorLeft = pos;
        }
     
        Console.WriteLine();
        return sb.ToString();
    }

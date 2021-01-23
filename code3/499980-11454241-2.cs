    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder();
                // you have alot of control on cursor position using
                // Console.SetCursorPosition(0, Console.CursorTop -1);
                List<DateTime> inputs = new List<DateTime>();
                ConsoleKeyInfo cki;
                Console.WriteLine("Start Typing...");
                Console.WriteLine("Press the Escape (Esc) key to quit: \n");
                do
                {
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Spacebar)
                    {
                        sb.Append(cki.KeyChar);
                    }
                    else if (cki.Key == ConsoleKey.Backspace)
                    {
                        Console.Write(" ");
                        Console.Write("\b");
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else if (cki.Key == ConsoleKey.Enter)
                    {
                        sb.Append(cki.KeyChar + " ");
                        Console.WriteLine("");
                    }
                    else
                    {
                        sb.Append(cki.KeyChar);
                    }
                    inputs.Add(DateTime.Now);
                } while (cki.Key != ConsoleKey.Escape);
                Console.WriteLine("");
                Console.WriteLine("=====================");
                Console.WriteLine("Word count: " + Regex.Matches(sb.ToString(), @"[A-Za-z0-9]+").Count);
                TimeSpan duration = inputs[inputs.Count - 1] - inputs[0];
            
                Console.WriteLine("Duration (secs): " + duration.Seconds);
                Console.ReadLine();
            }
        }
    }

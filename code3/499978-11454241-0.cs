    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DateTime> inputs = new List<DateTime>();
                int words = 0;
                ConsoleKeyInfo cki;
                Console.WriteLine("Start Typing...");
                Console.WriteLine("Press the Escape (Esc) key to quit: \n");
                do
                {
                    cki = Console.ReadKey();
                    //Console.Write(cki.Key.ToString());
                    if (cki.Key == ConsoleKey.Spacebar)
                    {
                        words++;
                    }
                    inputs.Add(DateTime.Now);
                } while (cki.Key != ConsoleKey.Escape);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Keystrokes: " + inputs.Count);
                Console.WriteLine("Words: " + words);
                TimeSpan duration = inputs[inputs.Count - 1] - inputs[0];
            
                Console.WriteLine("Duration (secs): " + duration.Seconds);
                Console.ReadLine();
            }
        }
    }

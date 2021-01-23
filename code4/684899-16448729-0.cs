    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(250);
                Console.Write(".");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true); // read key without displaying it
                    Console.WriteLine("");
                    Console.WriteLine("Key Pressed: " + key.KeyChar.ToString());
                }
            }
        }
    }

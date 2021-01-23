        static void Main(string[] args)
        {
            Environment.ExitCode = -1;
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(1000);
            }
            Environment.ExitCode = 0;
            Console.WriteLine("Done!");
        }

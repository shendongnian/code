    class Program
    {
        static void Main(string[] args)
        {
            // read 10 lines from the top of the console buffer
            foreach (string line in ConsoleReader.ReadFromBuffer(0, 0, (short)Console.BufferWidth, 10))
            {
                Console.Write(line);
            }
        }
    }

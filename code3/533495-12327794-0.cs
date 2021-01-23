    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Process.GetCurrentProcess().MainWindowHandle);
            Console.ReadKey();
        }
    }

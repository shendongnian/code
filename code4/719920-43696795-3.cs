    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(MyWork, "text");
            Console.ReadKey();
        }
        private static void MyWork(object argument)
        {
            Console.WriteLine("Argument: " + argument);
        }
    }

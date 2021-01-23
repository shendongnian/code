    class Program
    {
        static void Main()
        {
            bool result = Task.Factory.StartNew(SomePossibleFailingTask).Wait(1000);
            if (result == false)
            {
                Console.WriteLine("Something has gone wrong!");
            }
            Console.ReadKey();
        }
        public static void SomePossibleFailingTask()
        {
            Thread.Sleep(15000);
        }
    }

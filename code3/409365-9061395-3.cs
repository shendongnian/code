    class Program
    {
        private static Semaphore sem = new Semaphore(1, 1);
        static void Main(string[] args)
        {
            MyMethod();
            MyMethod();
        }
        private static void MyMethod()
        {
            if(sem.WaitOne(0))
            {
                try
                {
                    Console.WriteLine("Entered.");
                    MyMethod(); // recursive calls won't re-enter
                }
                finally
                {
                    sem.Release();
                }
            }
            else
            {
                Console.WriteLine("Not entered.");
            }
        }
    }

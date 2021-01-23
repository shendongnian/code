    class Program
    {
        static void Main(string[] args)
        {
            Decimal p = 0.00001m;
            Decimal i = 0m;
            DateTime start = new DateTime();
            DateTime stop = new DateTime();
            for (i = p; i <= 5; i = i + p)
            {
                Console.WriteLine("result is: " + i);
                if (i==p) start = DateTime.Now;
                if (i==5) stop = DateTime.Now;
            }
            Console.WriteLine("Time to compute: " + (stop-start));
        }
    }

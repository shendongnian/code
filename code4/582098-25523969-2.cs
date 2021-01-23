    class Program
     {        
       static void Main(string[] args)
        {
           
            Program programObj = new Program();
                programObj.mymethod();
                programObj.mynextmethod();
                      
        }
        void mynextmethod()
        {
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 60000000; i++)
            {
                int j = 0;
                if (i.Equals(j))
                    j = j + 1;
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time take in method" + elapsedMs);
           
            Console.ReadLine();
        }
        void mymethod()
        {
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < 60000000; i++)
            {
                int j = 0;
                if (i == j)
                    j = j + 1;
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time take in method" + elapsedMs);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int RETRIES = 10000000;
    
            string test = Guid.NewGuid().ToString();
    
            long ini = Environment.TickCount;
    
            string tmp;
            for (int i = 0; i < RETRIES; i++)
            {
                if (test.Length < 4)
                    tmp = test.Substring(4);
            }
    
            long timeSubstring = Environment.TickCount - ini;
    
            ini = Environment.TickCount;
    
            for (int i = 0; i < RETRIES; i++)
            {
                var data = new string(test.Take(4).ToArray());
            }
    
            long timeTake = Environment.TickCount - ini;
    
            Console.WriteLine("Time substring: {0}ms, Time take: {1}ms", 
                timeSubstring, timeTake);
    
            Console.ReadLine();
        }
    }

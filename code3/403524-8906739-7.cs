        static IEnumerable<int> GetInts(int i)
        {
            Console.WriteLine("GetInts connected");
            try
            {
                using (var ds = new DataSourceWrapper())
                {
                    while (i-- != 0)
                    {
                        Console.WriteLine("yield {0}", i);
                        yield return i;
                    }
                }
            }
            finally
            {
                // not called! 
                Console.WriteLine("GetInts disconnected");
            }
        }

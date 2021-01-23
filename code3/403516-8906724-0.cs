    static IEnumerable<int> GetInts(int i)
    {
        try
        {
            Console.WriteLine("GetInts connected");
            
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
            Console.WriteLine("GetInts disconnected");
        }
    }

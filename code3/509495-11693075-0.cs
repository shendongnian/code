    public void WriteBatch(IEnumerable<Tuple<string, int>> batch)
    {
        lock (myLock) 
        {
            foreach (var tuple in batch)
            {
                Console.WriteLine("{0} - {1}", tuple.Item1, tuple.Item2);
            }
            Console.WriteLine();
        }
    }

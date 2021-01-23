    private static BlockingCollection<int> _pool;
    public static void Main()
    {
        _pool = new BlockingCollection<int>();
        Task.Run(() => //This is run in another thread so it shows data is being taken out and put in at the same time
        {
            for(int i = 1; i <= 1000; i++)
            {
                _pool.Add(i);
            }
            _pool.CompleteAdding(); //Lets the foreach know no new items will be showing up.
        });
        
        //This will work on the items in _pool, if there is no items in the collection it will block till CompleteAdding() is called.
        Parallel.ForEach(_pool.GetConsumingEnumerable(), new ParallelOptions {MaxDegreeOfParallelism = 3}, Worker);
    }
    
    private static void Worker(int num)
    {
            // do a long process here
    } 

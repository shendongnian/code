    public void Start()
    {
        var bag = new ConcurrentBag<string>();
        for(var i = 0; i < COPY_OPERATIONS; i++)
        {
            Task.Factory.StartNew(() =>
            {
                StartCopy(bag);
            });
        }
    }
    public void StartCopy(ConcurrentBag<string> bag)
    {
        while (true)
        {
            // Loop until the bag is available to hand us a path to work on
            string path = null;
            while (!bag.IsEmpty && !bag.TryTake(out path))
            {}
            // Access the file via a stream and begin parsing it, dumping scores to the db
        }
    }

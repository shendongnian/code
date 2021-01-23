    //define a blocking collectiom
    var blockingCollection = new BlockingCollection<string>();
    
    //Producer
    Task.Factory.StartNew(() =>
    {
        while (true)
        {
            blockingCollection.Add("value" + count);
            count++;                    
        }
    });
     
    //consumer
    //GetConsumingEnumerable would wait until it find some item for work
    // its similar to while(true) loop that we put inside consumer queue
    Task.Factory.StartNew(() =>
    {
        foreach (string value in blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine("Worker 1: " + value);
        }                
    });

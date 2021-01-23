    var insertQueue = new BlockingCollection<Com.TibCo.As.Space.Tuple>();
    
    // Here, start a task that reads the queue and inserts items into the database
    var insertTask = new Task(() =>
    {
        while (!insertQueue.IsCompleted)
        {
            Com.Tibco.As.Space.Tuple tuple;
            if (insertQueue.TryTake(out tuple, -1))
            {
                inSpace_.Put(tuple);
            }
        }
    });
    insertTask.Start();
    Parallel.ForEach (
        dataSet.Tables[0].Rows,
        currRow =>
        {
            var tuple = Com.Tibco.As.Space.Tuple.Create();
            
            // create the tuple here
            // and then add it to the queue
            insertQueue.Add(tuple);
        });
    // tell the queue that you're done adding.
    insertQueue.CompleteAdding();
    // wait for the insert task to complete
    insertTask.Wait();

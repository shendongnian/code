    BlockingCollection<ProducerTask> buffer = new BlockingCollection<ProducerTask>(1);
    // producer task
    while(/* lines still available */)
    {
        // read 500 lines
        ProducerTask p = new ProducerTask();
        buffer.Add(p); // this will block until the consumer takes the previous task
    }
    // consumer task
    while(/* termination not received */)
    {
        ProducerTask p = buffer.Take(); // blocks if no task is available
        // put the lines in the grid
    }

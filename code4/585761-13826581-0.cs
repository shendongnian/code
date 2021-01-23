    // Asynchronously call DoWork
    MyTestServiceClient client = new MyTestServiceClient();
    IAsyncResult iar = client.BeginDoWork(null, null);
    // Sleep, dance, do the shopping, whatever
    Thread.Sleep(5000);
    bool requestCompletedInFiveSeconds = iar.IsCompleted;
    // When you're ready, remember to call EndDoWork to tidy up
    client.EndDoWork(iar);
    client.Close();

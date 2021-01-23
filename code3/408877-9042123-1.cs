    List<Data> GetData(CancellationToken cancel)
    {
     List<Data> dataA;
     List<Data> dataB;
     Task[] tasks = new Task[]
     {
       Task.Factory.StartNew(() => DataA()),
       Task.Factory.StartNew(() => DataNB()),
     };
     Task.WaitAll(tasks, cancel); // Block until all tasks complete or cancelled.
     if (cancellation.IsCancellationRequested)
       return new List<Data>();
     return dataA.Concat(dataB);
    }

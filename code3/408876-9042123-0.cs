    List<Data> dataA;
    List<Data> dataB;
    Task[] tasks = new Task[]
    {
       Task.Factory.StartNew(() => DataA()),
       Task.Factory.StartNew(() => DataNB()),
    };
    Task.WaitAll(tasks); // Block until all tasks complete.
    var datac = dataA.Concat(dataB);

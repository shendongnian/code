    var tasks = new Task[Environment.ProcessorCount];
    for (int i = 0; i< Environment.ProcessorCount; i++)
    {
        tasks [i] = Task.Factory.StartNew(() =>
        {
            // your Excel code here.                 
        });
    }
    Task.WaitAll(tasks);

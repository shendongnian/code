    var tasks = new List<Task>();
    for ...
    {
       Task compute = Task.Factory.StartNew(() => results.Add(Compute(originalObject)));
       tasks.Add(compute);
    }
 
    Task.WaitAll(tasks.ToArray());

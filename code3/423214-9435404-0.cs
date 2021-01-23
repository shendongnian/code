    Parallel.ForEach(ids, id =>
    {
        Console.WriteLine("Processing {0}", id);
        ProcessEmp(id);
    });

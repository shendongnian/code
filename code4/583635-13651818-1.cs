    Enumerable.Range(0, list.Count)
        .AsParallel()
        .WithDegreeOfParallelism(10)
        .ForAll(i =>
        {
            list[i] = Process(i);
        });

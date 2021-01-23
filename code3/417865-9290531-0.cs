    Parallel.ForEach(
        listOfWebpages,
        new ParallelOptions { MaxDegreeOfParallelism = 4 },
        webpage => { Download(webpage); }
    );

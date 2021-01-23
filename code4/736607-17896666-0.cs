    public IList<Result> GetResult()
    {
        return new Func<IEnumerable<Result>>[] { GetSomeItemsA, GetSomeItemsB, GetSomeItemsC  }
            .AsParallel()
            .SelectMany(f => f())
            .ToList();
    }

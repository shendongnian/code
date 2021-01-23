    public void DoWork(IEnumerable<Action> actions)
    {
        Parallel.Invoke(new ParallelOptions() { MaxDegreeOfParallelism = 10 }
            , actions.ToArray());
    }

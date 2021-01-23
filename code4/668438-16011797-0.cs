    List<Task> tasks = new List<Task>();
    var resolved = _container.Resolve<IScoreCalculator>();
    foreach (OrigineAgent origineAgent in Origine.Agents.ToList().AsParallel())
    {
        origineAgent.ScoreCalculator = resolved
        origineAgent.AgentExoVariables = AgentVars;
        Task t = Task.Factory.StartNew((arg) => { _migrationManager.Migrate((OrigineAgent)arg); }, origineAgent);
        tasks.Add(t);
    }
    Task.WaitAll(tasks.ToArray());

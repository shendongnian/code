    Assembly.GetEntryAssembly()
            .GetTypes()
            .Where(t => typeof(IEulerProblem).IsAssignableFrom(t))
            .Where(t => !t.IsInterface && !t.IsAbstract)
            .Select(t => Activator.CreateInstance(t) as IEulerProblem)
            .OrderBy(t => t.GetType().Name).ToList()
            .ForEach(p => p.SolveProblem());

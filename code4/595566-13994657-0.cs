    var problems = Assembly.GetExecutingAssembly().GetTypes()
                           .Where(t => !t.IsAbstract && typeof(Problem).IsAssignableFrom(t));
    
    foreach(var p in problems)
    {
        var euler = Activator.CreateInstance(p) as Problem;
        euler.Solve(); // ??
    }

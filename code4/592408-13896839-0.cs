    Type pType = typeof(Entity);
    var children = Enumerable.Range(1, iterations)
                   .SelectMany(i => Assembly.GetExecutingAssembly().GetTypes()
                   .Where(t => t.IsClass
                            && pType.IsAssignableFrom(t) && t != pType)
                   .Select(t => t.Name));

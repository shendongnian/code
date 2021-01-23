    Type pType = typeof(Entity);
    IEnumerableystring> children = Enumerable.Range(1, iterations)
       .SelectMany(i => Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => t.IsClass && t != pType)
                                && pType.IsAssignableFrom(t) 
                        .Select(t => t.Name));

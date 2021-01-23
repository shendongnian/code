    var nodes = tree.Flatten();
    var variables = nodes
        .OfType<Variable>()
        .GroupBy(x => x.Name)
        .Select(g => new Multication(g.First(), new Constant(g.Count())));
    var constants = nodes
        .OfType<Constant>()
        .Sum(x => x.Value);
    var result = new Addition(
        variables.Aggregate((x, y) => new Addition(x, y)), 
        constants);

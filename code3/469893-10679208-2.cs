    public override ProblemCollection Check(TypeNode type)
    {
        if (!type.Name.Name.EndsWith("Foo", StringComparison.Ordinal))
        {
            var resolution = GetResolution(type.Name.Name);
            var problem = new Problem(resolution, type)
                              {
                                  Certainty = 100,
                                  FixCategory = FixCategories.Breaking,
                                  MessageLevel = MessageLevel.Warning
                              };
            Problems.Add(problem);
        }
    
        return Problems;
    }

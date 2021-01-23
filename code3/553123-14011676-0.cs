    public static void ExpectedPropertiesExist<TSource, TDestination>(params
        Expression<Func<TDestination, object>>[] exclude)
    {
        var excludedProperties = exclude.Select(e => (e.Body as
            MemberExpression).Member.Name);
        var mappedProperties = typeof(TDestination).GetProperties()
            .Select(p => p.Name)
            .Except(excludedProperties);
    
        var sourceType = typeof(TSource);
    
        var baseTypeNames = sourceType.GetProperties().Select(b => b.Name).ToList();
        baseTypeNames.AddRange(sourceType.GetMethods().Select(b => b.Name));
    
        Assert.IsTrue(new HashSet<string>(baseTypeNames)
            .IsSupersetOf(mappedProperties));
    }

    // inititialize the dictionary
    Grandchild grandchild = null;
    Dictionary<Parent, int> dict = session.QueryOver<Parent>()
        .JoinQueryOver(p => p.Childs)
        .JoinAlias(c => c.GrandChilds, () => grandchild)
        .Select(Projections.Group<Parent>(p => p.Id), Projections.Sum(() => grandchild.Age))
        .AsEnumerable()
        .Cast<object[]>()
        .ToDictionary(
            array => session.Load<Parent>(array[0]),
            array => (int)array[1]
        );
    // initialize all Parent proxies
    session.QueryOver<Patient>()
        .WhereProperty(p => p.Id).In(dict.Keys.Select(p => p.Id))
        .ToList();

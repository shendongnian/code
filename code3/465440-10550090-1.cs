    using (var db = new MyContainer())
    {
        var orderSpec = orderSpecs[0];
        IOrderedEnumerable<DbVersion> dVersions;
        var mapping = new Dictionary<int, Func<DbVersion, object>>()
        {
            { 0, ver => ver.Name },
            { 1, ver => ver.Built },
            { 2, ver => ver.Id }
        };
        if (orderSpec.Descending)
            dVersions = db.Versions.OrderByDescending(mapping[orderSpec.Column]);
        else
            dVersions = db.Versions.OrderBy(mapping[orderSpec.Column]);
        foreach (var spec in orderSpecs.Skip(1))
        {
            if (spec.Descending)
                dVersions = dVersions.ThenByDescending(mapping[spec.Column]);
            else
                dVersions = dVersions.ThenBy(mapping[spec.Column]);
        }
    }

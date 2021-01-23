    EntityCollection result = proxy.RetrieveMultiple(expression);
    foreach (var entity in result.Entities)
    {
        var vsHeaders = entity.Attributes.Select(kvp => string.Format("{0}", kvp.Key));
        string sHeaders = string.Join(",", vsHeaders);
    }

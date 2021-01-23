    var namespaces = library.GetTypes().GroupBy(t => t.Namespace);
    foreach (var typesInNamespace in namespaces)
    {
        foreach (var type in typesInNamespace)
        {
          ...
        }
    }

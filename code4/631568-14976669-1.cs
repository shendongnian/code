    var namespaces = AppDomain.CurrentDomain
                         .GetAssemblies()
                         .SelectMany(a => a.GetTypes())
                         .Select(t => t.Namespace)
                         .Distinct()
                         // optionally .OrderBy(ns => ns) here to get sorted results
                         .ToList();

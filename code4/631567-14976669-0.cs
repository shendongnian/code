    var namespaces = AppDomain.CurrentDomain
                         .GetAssemblies()
                         .SelectMany(a => a.GetTypes())
                         .Select(t => t.Namespace)
                         .Distinct()
                         .ToList();

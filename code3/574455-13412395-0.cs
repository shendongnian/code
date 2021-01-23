    var types = typeof(TheTypeYouKnowAbout).Assembly.GetTypes()
                    .Where(t => t.Namespace == "TheNamespaceYouWant");
                    // Possibly add more restrictions, e.g. it must be
                    // public, and a class rather than an interface, and
                    // must have a public parameterless constructor...
    foreach (var type in types)
    {
        // Do something with the type
    }

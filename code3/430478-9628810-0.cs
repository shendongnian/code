    var props = typeof(Report).GetProperties()
                              .Where(p => p.GetCustomAttributes(typeof(Reportable), false)
                                           .Any());
    foreach (var prop in props)
    {
        Console.WriteLine(prop.Name);
    }

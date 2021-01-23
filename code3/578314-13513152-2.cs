    var props = typeof(Student).GetProperties();
    var names = props
        .Select(p => p.Name)
        .ToArray();
    var types = props
        .Select(p => p.PropertyType)
        .ToArray();
    for (int i = 0 ; i != names.Length ; i++) {
        Console.WriteLine("{0} {1}", names[i], types[i]);
    }

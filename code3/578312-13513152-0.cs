    var names = typeof(Student)
        .GetProperties()
        .Select(p => p.Name)
        .ToList();
    var types = typeof(Student)
        .GetProperties()
        .Select(p => p.PropertyType)
        .ToList();
    for (int i = 0 ; i != names.Count ; i++) {
        Console.WriteLine("{0} {1}", names[i], types[i]);
    }

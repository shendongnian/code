    foreach (var e in list) {
        var type = e.GetType();
        Console.WriteLine("====== {0}", type.FullName);
        foreach (var p in type.GetProperties()) {
            Console.WriteLine(p);
        }
    }

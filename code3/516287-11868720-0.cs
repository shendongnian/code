    Assembly assembly = Assembly.LoadFrom(currentFile.FullName);
    foreach (Type type in assembly.GetTypes())
    {
        if(!typeof(MyInterface).IsAssignableFrom(type))
            continue;
        var p = Activator.CreateInstance(type);
        _myList.Add((MyInterface)p, true);
    }

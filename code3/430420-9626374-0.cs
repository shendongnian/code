    object o = engine.Readfile(CSVPath);
    if(MyType.IsAssignableFrom(o.GetType())
        _Data = o;
    else
        Console.WriteLine("Mismatching types: {0} is not of type {1}", o.GetType(), MyType);

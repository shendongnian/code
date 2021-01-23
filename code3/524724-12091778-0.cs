    var props = TypeDescriptor.GetProperties(obj);
    foreach(var prop in props) {
        string name = prop.DisplayName;
        if(string.IsNullOrEmpty(name)) name = prop.Name;
        Console.WriteLine("{0}: {1}", name, prop.GetValue(obj));
    }

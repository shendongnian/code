    var properties = Type.GetType("My.NameSpace.MyClass").
        GetProperties(
            BindingFlags.DeclaredOnly |
            BindingFlags.Public |
            BindingFlags.Instance);

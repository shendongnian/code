    // Don't forget to null-check the result of GetType before using it!
    var properties = Assembly.GetType("My.NameSpace.MyClass").
        GetProperties(
            BindingFlags.DeclaredOnly |
            BindingFlags.Public |
            BindingFlags.Instance);

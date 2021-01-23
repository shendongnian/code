    // Don't forget to null-check the result of GetType before using it!
    // You will also need to specify the correct assembly. I've assumed
    // that MyClass is defined in the current executing assembly.
    var properties = Assembly.GetExecutingAssembly().GetType("My.NameSpace.MyClass").
        GetProperties(
            BindingFlags.DeclaredOnly |
            BindingFlags.Public |
            BindingFlags.Instance);

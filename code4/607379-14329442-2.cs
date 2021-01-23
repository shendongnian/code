    dynamic foo = new {Bar = 42, Baz = "baz"};
    Type fooType = foo.GetType();
    var valuesByProperty = fooType.
        GetProperties(BindingFlags.Public | BindingFlags.Instance).
        ToDictionary(p => p, p => p.GetValue(foo));

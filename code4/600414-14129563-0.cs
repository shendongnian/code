    var foo = new Foo<int>();
    foo.Items = new List<int>(new int[]{1,2,3});
    
    // this check is probably not needed, but safety first :)
    if (foo.GetType().GetProperties().Any(p => p.Name == "Items"))
    {
        var items = foo.GetType().GetProperty("Items").GetValue(foo, null);
    }

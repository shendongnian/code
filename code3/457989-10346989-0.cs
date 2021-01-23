    var fooType = typeof(Foo);
    foreach(var type in fooType.GetNestedTypes())
    {
        Console.WriteLine(type.Name);
        foreach(var field in type.GetFields())
        {
            Console.WriteLine("{0} = {1}",field.Name,field.GetValue(null));
        }
    }

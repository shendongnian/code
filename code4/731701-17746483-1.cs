    foreach (var propertyChain in prop)
    {
        var obj = (object)testA;
        foreach (var property in propertyChain)
        {
            obj = property.GetValue(obj, null);
            if (obj == null) {
                break;
            }
        }
        Console.WriteLine("{0} = {1}",
            string.Join(".", propertyChain.Select(x => x.Name)),
            obj);
    }

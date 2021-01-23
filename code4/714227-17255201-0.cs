    dynamic expando = new ExpandoObject();
    expando.SomeProperty = "1234";
    Console.WriteLine(expando.SomeProperty);
    Console.WriteLine(expando.SomeProperty.GetType().FullName); // string
    expando.SomeProperty = int.Parse(expando.SomeProperty);
    Console.WriteLine(expando.SomeProperty);
    Console.WriteLine(expando.SomeProperty.GetType().FullName); // int

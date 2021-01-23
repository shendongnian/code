    Test t = new Test();
    t.MyProperty1 = 123;
    t.MyProperty2 = "hello";
    t.MyProperty3 = new List<string>() { "one", "two" };
    
    var items = MyReflector.ReflectObject(t);
    
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }

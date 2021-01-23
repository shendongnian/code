    Test t = new Test();
    t.MyProperty1 = 123;
    t.MyProperty2 = "hello";
    t.MyProperty3 = new List<string>() { "one", "two" };
    t.MyTestProperty = new Test();
    t.MyTestProperty.MyProperty1 = 987;
    t.MyTestProperty.MyTestProperty = new Test();
    t.MyTestProperty.MyTestProperty.MyProperty2 = "goodbye";
    
    var items = MyReflector.ReflectObject(t);
        
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }

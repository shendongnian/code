    var pool = new GenericClassPool();
    pool.Add(new GenericClass<string> { Property = "String" });
    pool.Add(new GenericClass<int> { Property  = 0 });
    
    GenericClass<string> firstObject = pool.Get<string>();
    GenericClass<int> secondObject = pool.Get<int>();

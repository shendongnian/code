    foo aFoo = new foo(); // Make a foo
    List<foo> aFooList = new List<foo>(); // Make a foo list
    Console.WriteLine("\nUsing aFooList");
    for (int i = 0; i < 5; i++)
    {
        aFoo.bar = i;
        aFooList.Add(aFoo);
        Console.WriteLine(string.Join("", aFooList.Select(f => f.bar)));
    }
            
    var foos = Enumerable.Range(0, 5).Select(n => new foo { bar = n }).ToList();
    Console.WriteLine("\nUsing foos");
    Console.WriteLine(string.Join("", foos.Select(f => f.bar)));
    Console.ReadLine();

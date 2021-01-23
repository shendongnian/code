    var sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++) {
        Foo(null as string);
    }
    Console.WriteLine(sw.ElapsedMilliseconds);
    
    sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++) {
        Foo((string)null);
    }           
    Console.WriteLine(sw.ElapsedMilliseconds);
                
    sw = Stopwatch.StartNew();
    for (int i = 0; i < 1000000; i++) {
        Foo(default(string));
    }
    Console.WriteLine(sw.ElapsedMilliseconds);
    
    Console.ReadLine();

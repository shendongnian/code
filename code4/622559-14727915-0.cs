    void Bar()
    {
    	Foo(new {Position = 0});
    }
    
    void Foo(dynamic args)
    {
        Console.WriteLine(args.Position);
    }

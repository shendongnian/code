    object foo = 1;
    object bar = 1;
	
    // outputs False
    Console.WriteLine(foo == bar);
    // outputs True
    Console.WriteLine(foo.Equals(bar));
    // outputs True
    Console.WriteLine((int)foo == (int)bar);

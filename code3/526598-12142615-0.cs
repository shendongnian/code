    ClassA a = new ClassC();
    ClassC c = (ClassC)a; // Note, this is the SAME instance as in a
    Assert.AreSame(a, c);
    Console.WriteLine(a.Get()); // prints "from B"
    Console.WriteLine(c.Get()); // prints "from C"

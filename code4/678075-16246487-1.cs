    static void M() { Console.WriteLine("Hello!"); }
    static void N() { Console.WriteLine("Goodbye!"); }
    ...
    Action foo = M;
    foo(); // Hello!
    Action bar = N;
    bar(); // Goodbye!
    Action sum = foo + bar;
    sum(); // Hello! Goodbye!
    foo += bar; // Same as foo = foo + bar
    foo(); // Hello! Goodbye!

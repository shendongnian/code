    static void Foo(string input)
    {
        input = "In Foo";
    }
    ...
    string text = "hello";
    Foo(text);
    Console.WriteLine(text); // Still prints "hello"

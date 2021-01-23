    // Sample callbacks
    static void Foo(int i) { Console.WriteLine("Foo {0}", i); }
    static void Bar(string s) { Console.WriteLine("Bar {0}", s); }
    AddCallback(null, (Action<int>)(Foo));
    AddCallback(null, (Action<string>)(Bar));
    foreach (var callback in GetCallbacks<int>())
    {
        callback(42); // only calls Foo
    }

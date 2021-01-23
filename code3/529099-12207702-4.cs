    void SomeFunc(Action<bool,int> foo)
    {
        foo(true, 99);
        // stuff
    }
    void matchesDelegate(bool a1, int a2)
    {
        Console.WriteLine(string.Format("params: {0}, {1}", a1, a2));
    }
    SomeFunc(matchesDelegate);

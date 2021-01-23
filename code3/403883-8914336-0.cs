    public void Test()
    {
        string s = "Hello";
        Foo(out s);
    }
    public void Foo(out string s) //s is passed with "Hello" even if not usable
    {
        s = "Bye";
    }

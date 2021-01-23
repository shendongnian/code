    void Test(string y)
    {
        y = "bar";
    }
    void Test(ref string z)
    {
        z = "baz";
    }
    string x = "foo";
    Test(x);                 // x is still "foo"
    Test(ref x);             // x is now "baz"

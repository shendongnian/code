    public String doSomething(String s1, String s2) { ... }
    public String doSomethingElse(String s1, String s2) { ... }
    public String myMethod(
        Func<string, string, string> f1,
        Func<string, string, string> f2)
    {
        //code
        string result1 = f1("foo", "bar");
        string result2 = f2("bar", "baz");
        //code
    }
    ...
    myMethod(doSomething, doSomethingElse);

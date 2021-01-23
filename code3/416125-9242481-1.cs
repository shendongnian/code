    public void foo(string a, int b, bool c, string d) {}
    public void foo2(string a, string b, string c) {}
    ...
    var test1 = new object[] {"ASDF", 10, false, "QWER"};
    var test2 = new[] {"A", "B", "C"};
    
    test2.SendToMethod((Action<string, string, string>)foo);
    test1.SendToMethod((Action<string, int, bool, string>)foo2); 

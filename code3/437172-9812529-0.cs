    public int Foo(string s) { }      // OK, first method
    public int Foo(double d) { }      // OK, different type
    public void Foo(double x) { }     // Error, same parameter type, return
                                      // type and parameter name do not matter.
    public int Foo(string s, DateTime d) { }  // OK, diffent number of parameters.

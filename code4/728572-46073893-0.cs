    void myMethod(int? myParam) { }
    void myMethod(string myParam) { }
    void test 
    {
        string a = null;
        myMethod(a); // no problem here, a is of type string so 2nd overload will be used.
        myMethod(null); // not valid ! Compiler can't guess which one you want.
        myMethod((string) null); // valid, null is casted to string so 2nd overload is to be used.
    }

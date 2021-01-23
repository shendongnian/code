    void CallingMethod()
    {
        int a = 10;
        SomeMethod(ref a);
        ...
    }
    void SomeMethod(ref int b)
    {
        // here, the variable b holds a reference to CallingMethod's local variable "a".

    class A { }
    class B : A { }
    class C : A { }
    void SomeMethod(out A a)
    {
        a = new B();
    }
    C c;
    SomeMethod(c); // assigning new instance of B to variable of type C

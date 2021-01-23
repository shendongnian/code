    class A
    {
        virtual void Foo(int i) { Console.WriteLine(i); }
    }
    class B : A
    {
        override void Foo(int i, int j) { Console.WriteLine(i + j); }
    }
    // somewhere else
    void DoSomething(A a)
    {
        a.Foo(1);
    }
    // later
    DoSomething(new B()); // how will b.Foo get called inside DoSomething?

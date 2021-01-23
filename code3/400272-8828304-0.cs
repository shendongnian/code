    class B: A
    {
        void Foo()
        {
            B b = new B();
            A a = b;
            a.GetData() //B's GetData() will be called
            b.GetData() //B's GetData() will be called
        }
    }

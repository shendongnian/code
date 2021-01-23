    //third party
    class ClassA
    {
        void X();
    }
    class ClassB
    {
        void Y();
    }
    //your code
    interface IClassA
    {
        void X();
    }
    interface IClassB
    {
        void Y();
    }
    
    class MyClassA : ClassA, IClassA { }
    class MyClassB : ClassB, IClassB { }
    
    class MyClass : IClassA, IClassB
    {
        IClassA a = new MyClassA();
        IClassB b = new MyClassB();
        public void X()
        {
            a.X();
        }
    
        public void Y()
        {
            b.Y();
        }
    }

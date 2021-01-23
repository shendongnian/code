    interface IMyInterface
    {
        void MethodX();
    }
    
    class ClassA : IMyInterface
    {
        public void MethodX()
        {
             Console.WriteLine("MethodX from ClassA");
        }
    }
    class ClassB : IMyInterface
    {
        public void MethodX()
        {
             Console.WriteLine("MethodX from ClassB");
        }
    }
    
    class Foo
    {
        public void MyMethod(IMyInterface obj)
        {
            obj.MethodX();
        }
    }
    Foo f = new Foo();
    
    IMyInterface ca = new ClassA();
    f.MyMethod(ca);  // This Print MethodX from ClassA
    
    IMyInterface cb = new ClassB();
    f.MyMethod(cb);  // This Print MethodX from ClassB

    interface IMyInterface
    {
        void MethodX();
    }
    abstract class ClassBase: IMyInterface
    {
        public virtual void MethodX()
        {
            Console.WriteLine("MethodX from base class");
        }
    }
    
    // this will use base class implementation of MethodX
    class ClassA : ClassBase
    {
    }
    class ClassB : Classbase
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
    f.MyMethod(ca);  // This Print MethodX from ClassA, in this case BaseClass
    
    IMyInterface cb = new ClassB();
    f.MyMethod(cb);  // This Print MethodX from ClassB

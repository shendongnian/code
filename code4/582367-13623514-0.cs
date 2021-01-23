    class MyClass
    {
        public virtual void Test()
        {
            // Behaviour for MyClass
        }
    }
    class MyClass2 : MyClass
    {
        public override void Test()
        {
            // Behaviour for MyClass2
        }
    }
    private void Foo(MyClass cl)
    {
        cl.Test();
    }

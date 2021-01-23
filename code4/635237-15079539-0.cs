    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Constructor called!");
        }
    }
    abstract class X
    {
        void Do()
        {
            MyClass my = new MyClass();  // Should always print "Constructor called!"
            my = GetMyClass();
            // ...
        }
        
        protected abstract MyClass GetMyClass();
    }

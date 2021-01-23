    class SomeClass
    {
        Action action;
        
        public SomeClass()
        {
            action = () => Foo();
        }
        void Foo()
        {
        }
    }

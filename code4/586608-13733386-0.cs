    class ClassA
    {
        public virtual void DoSomething()
        {
            DoSomethingHelper(1); // when called from ClassB, it calls DoSomething from ClassA with an infinite recursion
        }
    
        public virtual void DoSomething(int someInt)
        {
            DoSomethingHelper(someInt);
        }
    
        private void DoSomethingHelper(int someInt)
        {
            // do something
        }
    }

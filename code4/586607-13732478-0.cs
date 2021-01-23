    class ClassA
    {
        public void DoSomething()
        {
            DoSomething(1); 
        }
    
        public void DoSomething(int someInt)
        {
            Console.WriteLine("a");
        }
    }
    
    class ClassB : ClassA
    {
        public new void DoSomething()
        {
            DoSomething(1);
        }
    
        public new void DoSomething(int someInt)
        {
            base.DoSomething();
        }
    }

    Class A
    {
        Public TabControl X {get; set;}
        ...//Stuff
    }
    //Method 1 -> Internal A
    Class B
    {
        public A thing {get;set;}
        
        private void someMethod()
        {
            A = new A();
            A.X.DoSomething();
        }
    }
    //Method 2 -> External A
    Class C
    {
        public void SomeFunction (A Parameter)
        {
             Parameter.X.DoSomething();
        }
    }

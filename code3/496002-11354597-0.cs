    class Program
    {
        static void Main(string[] args)
        {
            Class1 instance1 = new Class1();
            Class2 instance2 = new Class2();
    
            instance1.CriticalValueReached += instance2.DoSomething;
            instance2.TimeoutElapsed += instance1.DoSomething;
            // infinite loop
            while (true)
            {
                instance1.UpdateMethod(someValue);
                instance2.UpdateMethod();
            }
        }
    }
    
    class Class1
    {
        int Property;
        public event Action CriticalValueReached;
        public UpdateMethod(int argument)
        {
            Property += argument;
            if (Property == 3000)
                RaiseCriticalValueReached();
        }
        public void DoSomething()
        {
            // Whatever...
        }
        private void RaiseCriticalValueReached()
        {
            var handler = CriticalValueReached;
            if (handler != null)
                handler();
        }
    }
    
    class Class2
    {
        public event Action TimeoutElapsed;
        public UpdateMethod()
        {
            if (Time.GetTime() == SomeTime)
                RaiseTimeoutElapsed();
        }
        public void DoSomething()
        {
            // ...
        }
        private void RaiseTimeoutElapsed()
        {
            var handler = TimeoutElapsed;
            if (handler != null)
                handler();
        }
    }

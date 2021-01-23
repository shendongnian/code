    public class SomeClass
    {
        private ISomething _something;
    
        public SomeClass(string someParam)
        {
            _something = IOC.Get<ISomething>();
        }
    
        public void DoAThing()
        {
            _something.DoSomething();
        }
    }

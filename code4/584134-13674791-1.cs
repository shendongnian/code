    public class SomeClass
    {
        private ISomething _something;
    
        public SomeClass(ISomething something, string someParam)
        {
            _something = something;
        }
    
        public void DoAThing()
        {
            _something.DoSomething();
        }
    } 

    public class FooBarClass
    {
        private int _numberToReuse = 0;
        public void Foo()
        {
            _numberToReuse = 10;
        }
        
        public void Bar()
        {
            DoSomething(_numberToReuse);
        }
    }

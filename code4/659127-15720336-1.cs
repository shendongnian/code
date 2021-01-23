    internal class Foo
    {
        private readonly int _a;
        public int A 
        { 
            get
            {
                return _a;
            }
        }
    
        public Foo(int a)
        {
            _a = a;
        }
    }

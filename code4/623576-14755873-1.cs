    public ISpecialReturnType
    {
        String SomeText{ get; }
        int SomeValue{ get; }
    }
    
    class ABC{
        public ISpecialReturnType getStructA(){
            A a = //Get a value for a;
            return a;
        }
    
        private struct A : ISpecialReturnType
        {
            private String _SomeText;
            private int _SomeValue;
            
            public A(String someText, int SomeValue) { /*.. set the initial values..*/ }
            
            public String SomeText{ get { return _SomeText; } }
            public int SomeValue{ get { return _SomeValue; } }
        }
    }

    class A
    {
        public A(int a, int b, int c)
        {
        }
    }
    
    class B : A 
    {
        public B(int a, int b, int c) : base(a, b, c)
        {
        }
    
        public void blah(int something)
        {
        }
    }

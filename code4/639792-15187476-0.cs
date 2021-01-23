    public class A
    {
        public int aInt;
    
        public A()
        {
            B b = new B(this);
        }
    
        // Changes aInt
    }
    
    public class B
    {
        A _a;
    
        public B(A a)
        {
            _a = a;
        }
        // can use _a.aInt here
    }

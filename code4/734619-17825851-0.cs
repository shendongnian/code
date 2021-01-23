    public class A
    {
        public A()
        {
            B b = new B(this);   
        }
    }
    public class B
    {
        public B(A a)
        {
            
        }
    }

    public class A
    {
        public A(B b)
        {
        }
    }
    
    public class B
    {
        public B(C c)
        {
        }
    }
    
    public class C
    {
        public B(A a)
        {
        }
    }

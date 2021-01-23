    public class A
    {
        class B
        {
            public B()
            {
                A a = new A();
                int nb = a.nb;
            }
        }
    
        public int nb;
    }

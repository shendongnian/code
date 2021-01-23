    abstract class A
    {
        protected A()
        {
        }
        /* implementation details... */
    }
    public class B
    {
        public A GetInstance()
        {
            return new _A();
        }
        private class _A : A
        {
            public A()
            {
            }
        }
    }

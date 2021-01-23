    public abstract class BaseClass
    {
        public int SomeProperty
        {
            get
            {
                return CalcSomeProperty();
            }
        }
        protected abstract int CalcSomeProperty();
    }

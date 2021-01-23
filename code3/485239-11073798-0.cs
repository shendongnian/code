    public abstract class A
    {
        protected abstract W ConvertToW();
        public static explicit operator W(A a)
        {
            return a.ConvertToW();
        }
    }

    public abstract class BaseClass
    {
        protected BaseClass()
        {
            _someProperty = new Lazy<int>(CalcSomeProperty);
        }
        public int SomeProperty
        {
            get
            {
                return _someProperty.Value;
            }
        }
        protected abstract int CalcSomeProperty();
        private readonly Lazy<int> _someProperty;
    }

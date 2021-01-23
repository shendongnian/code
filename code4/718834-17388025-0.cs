    class BaseMyClass
    {
        private bool _isLoaded;
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }
        protected virtual void Load()
        {
            _isLoaded = true;
        }
    }
    class MyClass : BaseMyClass
    {
        public void Method1()
        {
            //does whatever
        }
        protected override void Load()
        {
            //does a lot of things and then...
            base.Load()
        }
    }

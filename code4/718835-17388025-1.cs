    public class BaseMyClass
    {
        private bool _isLoaded;
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }
        public virtual void Load()
        {
            _isLoaded = true;
        }
    }
    public class MyClass : BaseMyClass
    {
        public void Method1()
        {
            //does whatever
        }
        public override void Load()
        {
            //does a lot of things and then...
            base.Load();
        }
    }

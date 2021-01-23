    public class MyClass
    {
        bool _isLoaded;
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }
        public void Method1()
        {
            Contract.Ensures(this._isLoaded == Contract.OldValue(this._isLoaded));
            //does whatever
            _isLoaded = false;
        }
        public void Method2()
        {
            Contract.Ensures(this._isLoaded == Contract.OldValue(this._isLoaded));
            //does another thing
        }
        public void Load()
        {
            //does a lot of things and then...
            _isLoaded = true;
        }
    }

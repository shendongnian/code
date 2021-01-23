    public class Bar
    {
        private bool _initializing;
        private string _foo;
        public string Foo
        {
            set
            {
                _foo = value;
                if(!_initializing)
                    NotifyOnPropertyChange();
            }
        }
        public Bar()
        {
            _initializing = true;
            Foo = "bar";
            _initializing = false;
        }
    }

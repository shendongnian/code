    class A
    {
        // May be set by a code or by an user.
        public string Property
        {
            set { OnPropertyChanged(EventArgs.Empty); }
        }
        // This is required
        protected virtual void OnPropertyChanged(EventArgs e)
        {
            PropertyChanged(this, e);
        }
        public EventHandler PropertyChanged;
    }
    // Inject MyA instead of A
    class MyA : A
    {
        private bool _dontDoThis;
        public string MyProperty
        {
            set
            {
                try
                {
                    _dontDoThis = true;
                    Property = value;
                }
                finally
                {
                    _dontDoThis = false;
                }
            }
        }
        protected override void OnPropertyChanged(EventArgs e)
        {
            // Also third parties will be not notified
            if (_dontDoThis)
                return;
            base.OnPropertyChanged(e);
        }
    }
    class B
    {
        private MyA _a;
        public B(MyA a)
        {
            _a = a;
            _a.PropertyChanged += Handler;
        }
        void Handler(object s, EventArgs e)
        {
            // Now we know, that the event is not raised by us.
        }
        public void MakeProblem()
        {
            _a.MyProperty = "no problem";
        }
    }

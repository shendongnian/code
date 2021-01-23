    class A
    {
        // May be set by a code or by an user.
        public string Property
        {
            set { if (!_dontDoThis) PropertyChanged(this, EventArgs.Empty); }
        }
        public EventHandler PropertyChanged;
        bool _dontDoThis;
    }
    class B
    {
        private class ACallWrapper : IDisposable
        {
            private B _parent;
            public ACallWrapper(B parent)
            {
                _parent = parent;
                _parent._a._dontDoThis = true;
            }
        
            public void Dispose()
            {
                _parent._a._dontDoThis = false;
            }
        }
            
        private A _a;
        public B(A a)
        {
            _a = a;
            _a.PropertyChanged += Handler;
        }
        void Handler(object s, EventArgs e)
        {
            // Who changed the Property?
        }
        public void MakeProblem()
        {
            using (new ACallWrapper(this))
                _a.Property = "make a problem";
        }
    }

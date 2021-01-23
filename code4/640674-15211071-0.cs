    public sealed class RedirectableDoWorkEventHandler
    {
        public RedirectableDoWorkEventHandler(DoWorkEventHandler handler)
        {
            Contract.Requires(handler != null);
            _handler = handler;
        }
        public DoWorkEventHandler Handler
        {
            get
            {
                return _handler;
            }
            set
            {
                Contract.Requires(value != null);
                _handler = value;
            }
        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            _handler(sender, e);
        }
        private DoWorkEventHandler _handler;
    }

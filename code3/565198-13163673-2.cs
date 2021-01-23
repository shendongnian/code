        private Func<ProtocolBaseClass> _createProtocol;
        public ReportProxy(Func<ProtocolBaseClass> createProtocol)
        {
            _createProtocol= createProtocol;
        }
        public void DoSomething()
        {
            ProtocolBaseClass protocol = _createProtocol();
            ...
        }

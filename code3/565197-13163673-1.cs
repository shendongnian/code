    public class ReportProxy
    {
        private IProtocolFactory _factory;
        public ReportProxy(IProtocolFactory factory)
        {
            _factory = factory;
        }
        public void DoSomething()
        {
            ProtocolBaseClass protocol = _factory.Create();
            ...
        }
    }

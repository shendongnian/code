    public class FooContextService {
        private readonly FooContext _ctx;
        public FooContext Context { get { return _ctx; } }
        public FooContextService() : this(true) { }
        public FooContextService(bool proxyCreationEnabled) {
            _ctx = new FooContext();
            _ctx.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }
    }

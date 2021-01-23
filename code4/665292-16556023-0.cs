    public class FooContextService {
        private readonly FooContext _ctx;
        public FooContext Context { get { return _ctx; } }
        public FooContextService() {
            _ctx = new FooContext();
        }
    }

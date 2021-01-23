    public class UnicornService {
        private readonly FooContext _ctx;
        public UnicornService(FooContextService contextService) {
            if (contextService == null)
                throw new ArgumentNullException("contextService");
            _ctx = contextService.Context;
        }
        public ICollection<Unicorn> GetList() {
            return _ctx.Unicorns.ToList();
        }
    }
    public class DragonService {
        private readonly FooContext _ctx;
        public DragonService(FooContextService contextService) {
            if (contextService == null)
                throw new ArgumentNullException("contextService");
            _ctx = contextService.Context;
        }
        public ICollection<Dragon> GetList() {
            return _ctx.Dragons.ToList();
        }
    }

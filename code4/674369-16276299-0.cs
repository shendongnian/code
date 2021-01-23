    public class TestAdapter : IocAdapter
    {
        private readonly object[] _handlers;
    
        public TestAdapter(params object[] handlers)
        {
            _handlers = handlers;
        }
    
        public IEnumerable<object> GetAllInstances(Type desiredType)
        {
            return _handlers;
        }
    }

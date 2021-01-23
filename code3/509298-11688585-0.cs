        public class HandlerFactory
    {
        private Dictionary<string, IHandler> _handlers = new Dictionary<string,IHandler>();
        public HandlerFactory()
        {
            _handlers.Add("AMOUNT", new AmountValidator());
            _handlers.Add("FLOW", new FlowValidator());
        }
        public IHandler Create(string key)
        {
            IHandler result;
            _handlers.TryGetValue(key, out result);
            return result;
        }
    }

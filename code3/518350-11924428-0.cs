    public class EventWaiter
    {
        private AutoResetEvent _autoResetEvent = new AutoResetEvent(false);
        private EventInfo _event = null;
        private object _eventContainer = null;
    
        public EventWaiter(object eventContainer, string eventName)
        {
            _eventContainer = eventContainer;
            _event = eventContainer.GetType().GetEvent(eventName);
        }
        public void WaitForEvent()
        {
            Delegate handler = CreateHandler();
    
            _event.AddEventHandler(_eventContainer, handler);
    
            _autoResetEvent.WaitOne();
    
            _event.RemoveEventHandler(_eventContainer, handler);
    
        }
        
        private Delegate CreateHandler()
        {
            var invokeMethod = _event.EventHandlerType.GetMethod("Invoke");
            var invokeParameters = invokeMethod.GetParameters();
            var handlerParameters = invokeParameters.Select(p => Expression.Parameter(p.ParameterType, p.Name)).ToArray();
            var body = Expression.Call(Expression.Constant(_autoResetEvent), "Set", null);
            var handlerExpression = Expression.Lambda(_event.EventHandlerType, body, handlerParameters);
            return handlerExpression.Compile();
        }
    }

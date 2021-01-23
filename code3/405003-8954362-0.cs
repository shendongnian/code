    public class HandlerTypeSelector : DefaultTypedFactoryComponentSelector
    {
        private readonly WindsorContainer container;
        public HandlerTypeSelector(WindsorContainer container)
        {
            this.container = container;
        }
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            if (method.Name == "GetMessageHandler")
            {
                var type = arguments[0].ToString();
                var messageHandlers = container.ResolveAll<IMessageHandler>();
                var single = messageHandlers.SingleOrDefault(h => h.GetMessageType() == type);
                if( single != null)
                    return single.GetType().FullName;
            }
            return base.GetComponentName(method, arguments);
        }
    }

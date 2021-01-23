    public class EventHooks
    {
        private class EventHooksEquality : IEqualityComparer<Tuple<string, object>>
        {
            public bool Equals(Tuple<string, object> x, Tuple<string, object> y)
            {
                return x.Item1.Equals(y.Item1) && object.ReferenceEquals(x.Item2, y.Item2);
            }
            public int GetHashCode(Tuple<string, object> obj)
            {
                return obj.Item1.GetHashCode();
            }
        }
        
        public void CheckSecurity(string eventName, object container) 
        {
            // Add your security code that checks attributes and the likes here
        }
        
        private abstract class BaseHookHandler
        {
            protected BaseHookHandler(object container, string eventName, EventHooks hooks)
            {
                this.hooks = hooks;
                this.container = container;
                this.eventName = eventName;
            }
            protected string eventName;
            protected object container;
            protected EventHooks hooks;
        }
        private class HookHandler<T1> : BaseHookHandler
        {
            public HookHandler(object container, string eventName, EventHooks hooks)
                : base(container, eventName, hooks)
            {
            }
            public void Handle(T1 t1)
            {
                hooks.CheckSecurity(eventName, container);
            }
        }
        private class HookHandler<T1, T2> : BaseHookHandler
        {
            public HookHandler(object container, string eventName, EventHooks hooks)
                : base(container, eventName, hooks)
            {
            }
            public void Handle(T1 t1, T2 t2)
            {
                hooks.CheckSecurity(eventName, container);
            }
        }
        // add more handlers here...
        public void HookAll(object obj)
        {
            foreach (var eventHandler in obj.GetType().GetEvents()) 
            {
                Hook(obj, eventHandler.Name);
            }
        }
        public void Hook(object obj, string eventHandler)
        {
            if (obj == null)
            {
                throw new Exception("You have to initialize the object before hooking events.");
            }
            // Create a handler with the right signature
            var field = obj.GetType().GetEvent(eventHandler);
            var delegateInvoke = field.EventHandlerType.GetMethod("Invoke");
            Type[] parameterTypes = delegateInvoke.GetParameters().Select((a) => (a.ParameterType)).ToArray();
            
            // Select the handler with the correct number of parameters
            var genericHandler = Type.GetType(GetType().FullName + "+HookHandler`" + parameterTypes.Length);
            var handlerType = genericHandler.MakeGenericType(parameterTypes);
            var handlerObject = Activator.CreateInstance(handlerType, obj, eventHandler, this);
            var handler = handlerType.GetMethod("Handle");
            // Create a delegate
            var del = Delegate.CreateDelegate(field.EventHandlerType, handlerObject, handler);
            // Add the handler to the event itself
            field.AddEventHandler(obj, del);
        }
    }

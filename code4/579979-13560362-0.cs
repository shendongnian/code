        public class MessageDispatcher {
            private readonly Dictionary<Type, MulticastDelegate> registeredHandlers = new Dictionary<Type, MulticastDelegate>();
            private delegate void MessageActionDelegate<in T>(T message);
            public void Register<T>(Action<T> action) {
                Type messageType = typeof (T);
                if (registeredHandlers.ContainsKey(messageType)) {
                    var messageDelegate = (MessageActionDelegate<T>) registeredHandlers[messageType];
                    registeredHandlers[messageType] = messageDelegate + new MessageActionDelegate<T>(action);
                }
                else {
                    registeredHandlers.Add(messageType, new MessageActionDelegate<T>(action));
                }
                
            }
            public void Deregister<T>() {
                Type messageType = typeof (T);
                if (registeredHandlers.ContainsKey(messageType)) {
                    registeredHandlers.Remove(messageType);
                }
            }
            public void DeregisterAll() {
                registeredHandlers.Clear();
            }
            public void Send<T>(T message) {
                Type messageType = typeof (T);
                if (!registeredHandlers.ContainsKey(messageType)) return;
                ((MessageActionDelegate<T>) registeredHandlers[messageType])(message);
            }
        }

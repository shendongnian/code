    using System;
    using System.Collections.Generic;
    using System.Reflection;
    
    namespace QuickFix
    {
        /// <summary>
        /// Helper class for delegating message types for various FIX versions to
        /// type-safe OnMessage methods, supports handling of incoming and outgoing messages separatelly
        /// </summary>
        public abstract class DirectedMessageCracker
        {
            private readonly Dictionary<Type, MethodInfo> _toHandlerMethods = new Dictionary<Type, MethodInfo>();
            private readonly Dictionary<Type, MethodInfo> _fromHandlerMethods = new Dictionary<Type, MethodInfo>();
    
            protected DirectedMessageCracker()
            {
                Initialize(this);
            }
    
            private void Initialize(Object messageHandler)
            {
                var handlerType = messageHandler.GetType();
    
                var methods = handlerType.GetMethods();
                foreach (var m in methods)
                {
                    if (IsToHandlerMethod(m))
                        _toHandlerMethods[m.GetParameters()[0].ParameterType] = m;
                    else if (IsFromHandlerMethod(m))
                        _fromHandlerMethods[m.GetParameters()[0].ParameterType] = m;
                }
            }
    
            static public bool IsToHandlerMethod(MethodInfo m)
            {
                return IsHandlerMethod("OnMessageTo", m);
            }
    
            static public bool IsFromHandlerMethod(MethodInfo m)
            {
                return IsHandlerMethod("OnMessageFrom", m);
            }
    
            static public bool IsHandlerMethod(string searchMethodName, MethodInfo m) 
            {
                return (m.IsPublic
                    && m.Name.StartsWith(searchMethodName)
                    && m.GetParameters().Length == 2
                    && m.GetParameters()[0].ParameterType.IsSubclassOf(typeof(Message))
                    && typeof(SessionID).IsAssignableFrom(m.GetParameters()[1].ParameterType)
                    && m.ReturnType == typeof(void));
            }
    
            /// <summary>
            /// Process ("crack") a FIX message and call the registered handlers for that type, if any
            /// </summary>
            /// <param name="handlerMethods"></param>
            /// <param name="message"></param>
            /// <param name="sessionID"></param>
            private void Crack(IDictionary<Type, MethodInfo> handlerMethods, Message message, SessionID sessionID)
            {
                var messageType = message.GetType();
                MethodInfo handler;
    
                if (handlerMethods.TryGetValue(messageType, out handler))
                    handler.Invoke(this, new object[] { message, sessionID });
                else
                    throw new UnsupportedMessageType();
            }
    
            /// <summary>
            /// Process ("crack") an INCOMING FIX message and call the registered handlers for that type, if any
            /// </summary>
            /// <param name="message"></param>
            /// <param name="sessionID"></param>
            public void CrackFrom(Message message, SessionID sessionID)
            {
                Crack(_fromHandlerMethods, message, sessionID);
            }
    
            /// <summary>
            /// Process ("crack") an OUTGOING FIX message and call the registered handlers for that type, if any
            /// </summary>
            /// <param name="message"></param>
            /// <param name="sessionID"></param>
            public void CrackTo(Message message, SessionID sessionID)
            {
                Crack(_toHandlerMethods, message, sessionID);
            }
        }
    }

    public static void assertSubscription<EventHandlerType>(object handler, object subscriber) {
                var inapropriate = false;
                try {
                    if (!typeof(EventHandlerType).IsSubclassOf(typeof (Delegate)) ||
                         typeof(EventHandlerType).GetMethod("Invoke").ReturnType != typeof(void))
                        inapropriate = true;
                } catch (AmbiguousMatchException) {
                    inapropriate = true;
                } finally {
                    if (inapropriate) throw new Exception("Inapropriate Delegate: " + typeof(EventHandlerType).Name);
                }
    
                var handlerField = subscriber.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                                .First(h => h.FieldType.IsInstanceOfType(handler));
    
                var handlerInstance = handlerField.GetValue(subscriber);
                var someEventField = handlerInstance.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                                .First(f => f.FieldType.IsAssignableFrom(typeof(EventHandlerType)));
    
                var eventInstance = (Delegate)someEventField.GetValue(handlerInstance);
                var subscribedMethod = eventInstance.GetInvocationList()
                        .FirstOrDefault(d => d.Method.DeclaringType != null && d.Method.DeclaringType.IsInstanceOfType(subscriber));
    
                Assert.That(subscribedMethod, Is.Not.Null);
            }

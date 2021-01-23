    public static class UIElementExtensions
    {
        public static void InsertEventHandler(this UIElement element, int index, RoutedEvent routedEvent, Delegate handler)
        {
            // get EventHandlerStore
            var prop = typeof(UIElement).GetProperty("EventHandlersStore", BindingFlags.NonPublic | BindingFlags.Instance);
            var eventHandlerStoreType = prop.PropertyType;
            var eventHandlerStore = prop.GetValue(element, new object[0]);
            // get indexing operator
            PropertyInfo indexingProperty = eventHandlerStoreType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(x => x.Name == "Item" && x.GetIndexParameters().Length == 1 && x.GetIndexParameters()[0].ParameterType == typeof(RoutedEvent));
            object handlers = indexingProperty.GetValue(eventHandlerStore, new object[] { routedEvent });
            if (handlers == null)
            {
                // just add the handler as there are none at the moment so it is going to be the first one
                if (index != 0)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                element.AddHandler(routedEvent, handler);
            }
            else
            {
                // create routed event handler info
                var constructor = typeof(RoutedEventHandlerInfo).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Single();
                var handlerInfo = constructor.Invoke(new object[] { handler, false });
                var insertMethod = handlers.GetType().GetMethod("Insert");
                insertMethod.Invoke(handlers, new object[] { index, handlerInfo });
            }
        }
    }
    

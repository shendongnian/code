        public static RoutedEvent GetEvent(this UIElement source, string eventName)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (string.IsNullOrEmpty(eventName))
                throw new ArgumentException("eventName");
            // check if the type is directly in there, otherwise you need a second pass and a more general approach
            RoutedEvent routedEvent = null;
            
            // this may return null...
            RoutedEvent[] events = EventManager.GetRoutedEventsForOwner(source.GetType());
            
            if (events != null)
                routedEvent = events.FirstOrDefault(p => p.Name == eventName);
            return routedEvent ?? EventManager.GetRoutedEvents().FirstOrDefault(p => p.OwnerType.IsInstanceOfType(source) && p.Name == eventName);
        }
        public static void RaiseEvent(this UIElement source, string eventName)
        {
            RoutedEvent routedEvent = GetEvent(source, eventName);
            
            if (routedEvent != null)
                source.RaiseEvent(new RoutedEventArgs(routedEvent, source));
        }
    }

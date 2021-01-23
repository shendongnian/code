    // Subclass of RoutedEventArgs that allows us to easily and nicely pass the message
    // to be logged
    public class LogEventArgs : RoutedEventArgs
    {
        public string Msg { get; set; }
        public LogEventArgs(RoutedEvent routedEvent, Object sender, string Msg)
            :base(routedEvent, sender)
        {
            this.Msg = Msg;
        }
    }
    
    // This is the Delegate that's used to grab the Log message
    public delegate void RoutedLogEventHandler(Object sender, RoutedEventArgs e);
    // This works as the abstraction layer that will allow UC's to raise LOG messages
    // and allow your implementation to alter the way it handles those LOG messages.
    // Since we're doing this with a routed event, we need an DependencyObject to
    // reigster it.
    public class LogServices :UIElement
    {        
        public static RoutedEvent LogEvent;
        
        // Static constructor, registers the event
        static LogServices()
        {
            LogEvent = EventManager.RegisterRoutedEvent("Log", RoutingStrategy.Bubble, typeof(RoutedLogEventHandler), typeof(UIElement));
        }
        // This helps raise the relevant shared event
        public static void RaiseLog(string Msg, UIElement sender)
        {
            sender.RaiseEvent(new LogEventArgs(LogEvent, sender, Msg)); 
        }
    }

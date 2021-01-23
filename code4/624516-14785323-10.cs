    enum EventType 
    { 
        Busy, 
        NotBusy 
    }
    class StreamEvent 
    { 
         public EventType Type {get; set;} 
         public StreamEvent(EventType type) { Type = type;}
    }

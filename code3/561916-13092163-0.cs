    class MyObject
    {
        protected EventHandlerList Events = new EventHandlerList();
    
        public static Event1Key = new object();
        public event Event1
        {
            add { Events.AddHandler(Event1Key, value); }
            remove { Events.RemoveHandler(Event1Key, value); }
        }
    }

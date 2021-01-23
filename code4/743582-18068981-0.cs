    class Capture
    {
        private readonly EventFilter filter;
        public Capture(EventFilter filter)
        {
            this.filter = filter;
        }
        public int Method(ref object userData, ref SDL_Event @event)
        {
            this.filter(userData, new Event(ref event));
            return 0;
        }
    }
    public static void AddEventWatch(EventFilter filter, object userData)
    {
        var capture = new Capture(filter);
        SDL_AddEventWatch(capture.Method, ref userData);
    }

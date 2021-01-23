    class Map<T> where T : EventArgs
    {
        Dictionary<string, EventHandler<T>> map;
        public Map()
        {
            map = new Dictionary<string, EventHandler<T>>();
        }
        public EventHandler<T> this[string key]
        {
            get
            {
                return map[key];
            }
            set
            {
                map[key] = value;
            }
        }
    }

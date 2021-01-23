    static class Map
    {
        static Dictionary<Type, object> maps = new Dictionary<Type, object>();
        public static Map<U> Get<U>() where U : EventArgs
        {
            Type t = typeof(U);
            if (!maps.ContainsKey(t))
                maps[t] = new Map<U>();
            Map<U> map = (Map<U>)maps[t];
            return map;
        }
    }

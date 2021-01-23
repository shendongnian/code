    class List
    {
        Type[] _types;
        public List()
        {
            _types = GetType().GetGenericArguments();
        }
    }

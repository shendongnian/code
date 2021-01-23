    class ObjectReference<T>
       where T : new()
    {
        private T _obj = new T();
        public void CreateNewObject()
        {
            _obj = new T();
        }
        public T Value { get return _obj; }
    }

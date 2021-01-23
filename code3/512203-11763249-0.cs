    class MyFactory<T> where T : new()
    {
        public T CreateMyStuff()
        {
            return new T();
        }
    }

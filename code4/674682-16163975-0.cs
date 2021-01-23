    class UselessFactory<T> where T : UselessBase, new()
    {
        public T CreateUseless(string msg)
        {
            return new T() { Message = msg };
        }
    }

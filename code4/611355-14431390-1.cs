    class Base<T> : IDisposable
        where T : Base<T>, new()
    {
        private static Dictionary<int, T> dict = new Dictionary<int, T>();
        private static T Get(int handle)
        {
            if (!dict.ContainsKey(handle))
                dict[handle] = new T(); //or throw an exception
            return dict[handle];
        }
        private static bool Remove(int handle)
        {
            return dict.Remove(handle);
        }
        public static T GetInstance(int handle)
        {
            T t = Base<T>.Get(handle);
            t._handle = handle;
            return t;
        }
        protected int _handle;
        protected Base() { }
        public void Dispose()
        {
            Base<T>.Remove(this._handle);
        }
    }
    class A : Base<A> { }

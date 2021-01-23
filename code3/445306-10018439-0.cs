    public sealed class HttpSessionState : ICollection, IEnumerable
    {
        private IHttpSessionState _container;
    ...
        public void Add(string name, object value)
        {
            this._container[name] = value;
        }
        public object this[string name]
        {
            get
            {
                return this._container[name];
            }
            set
            {
                this._container[name] = value;
            }
        }
    ...
    }

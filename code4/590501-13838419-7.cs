    class GenericFacade<T> where T : new()
    {
        private readonly t = new T();
        public void CallOnInternal(string name, params object[] parameters)
        {
            var paramTypes = parameters.Select(p => typeof(p))
            var match = typeof(T).GetMethodByNameThenSig(
                name,
                typeof(void),
                paramTypes);
            match.Invoke(this.t, parameters);
        }
        public TResult CallOnInternal<TResult>(string name, params object[] parameters)
        {
            var paramTypes = parameters.Select(p => typeof(p))
            var match = typeof(T).GetMethodByNameThenSig(
                name,
                typeof(TResult),
                paramTypes);
            return (TResult)match.Invoke(this.t, parameters);
        }
    }

    class SemiGenericFacade<T> where T : new()
    {
        private readonly t = new T();
        public void CallVoidOnT(string name, params object[] parameters)
        {
            var paramTypes = parameters.Select(p => typeof(p))
            var match = typeof(T).GetMethodBySig(typeof(void), paramTypes)
                .Single(mi => mi.Name == name);
            match.Invoke(this.t, parameters);
        }
    }

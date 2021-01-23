    public class PerConstructorScopeAccessor : IScopeAccessor
    {
        private static IDictionary<int, ILifetimeScope> Cache = new ConcurrentDictionary<int, ILifetimeScope>();
        public ILifetimeScope GetScope(Castle.MicroKernel.Context.CreationContext context)
        {
            int key = GetContextKey(context);
            if (!Cache.ContainsKey(key))
                Cache.Add(key, new DefaultLifetimeScope());
            return Cache[key];
        }
        private int GetContextKey(Castle.MicroKernel.Context.CreationContext context)
        {
            int hash = 0;
           
            foreach (var value in context.AdditionalArguments.Values)
            {
                hash = HashCode.CombineHashCode(hash, value.GetHashCode());
            }
            return hash;
        }
        #region IDisposable
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

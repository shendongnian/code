    public class LazyHeavyDependency : IHeavyDependency 
    {
        private readonly Lazy<IHeavyDependency> lazy;
        public LazyHeavyDependency(Lazy<IHeavyDependency> lazy)
        {
            this.lazy = lazy;
        }
        void IHeavyDependency.DoWork()
        {
            this.lazy.Value.DoWork();
        }
    }

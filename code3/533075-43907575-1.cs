    public sealed class Singleton
    {
        static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        private Singleton() { }
        
        public static Singleton Instance => lazy.Value;
    }

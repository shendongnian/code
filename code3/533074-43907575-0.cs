    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>();
        private Singleton() { }
        
        public static Singleton Instance => lazy.Value;
    }

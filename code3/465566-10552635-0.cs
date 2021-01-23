    public sealed class LazySingleton
    {
        private readonly static Lazy<LazySingleton> instance = 
            new Lazy<LazySingleton>(() => new LazySingleton() );
        private LazySingleton() { }
        public static LazySingleton Instance
        {
            get { return instance.Value; }
        }
    }

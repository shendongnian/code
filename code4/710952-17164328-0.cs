    public sealed class Singleton
    {
        // I'd usually make it a property in real code, backed by a readonly field
        public static readonly Singleton Instance;
        static Singleton()
        {
            Instance = new Singleton();
        }
        private Singleton()
        {
            // Only invoked from the static constructor
        }
    }

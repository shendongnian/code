    public sealed class Singleton
    {
        public static readonly Singleton _instance = new Singleton();
        private Singleton()
        {
        }
    }

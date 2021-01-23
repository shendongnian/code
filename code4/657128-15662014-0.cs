    public class Singleton
    {
        public static Singleton Instance;
        static Singleton
        {
            Instance = new Singleton();
        }
        private Singleton()
        {
        }
    }
    public class SomeOtherClass
    {
        public static Singleton CompileError = new Singleton();
        public static Singleton CompileOK = Singleton.Instance;
    }

    public class Singleton
    {
        private static Singleton instance = new Singleton();
        private Singleton()
        {
        }
          
        public static GetInstance()
        {
            return instance;
        }
    }

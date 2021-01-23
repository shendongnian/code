    public class Singleton
    {
        private static Singleton _instance;
        public static Singleton Instance
        {
             get 
             { 
                if (_instance == null)
                {
                     _instance = DoARuntimeCheck() 
                                 ? new Singleton() 
                                 : new BetterSingleton();
                }
                return _instance;
             }
        }
        public virtual void ActualMethod() { // whatever }
    }
    public class BetterSingleton : Singleton
    {
        public override void ActualMethod() { // newer implementation }
    }

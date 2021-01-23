    public class Singleton
    {
        private static Singleton _instance;
        public static Singleton Instance
        {
             get 
             { 
                if (_instance == null)
                {
                     // This is the original code.
                     //_instance = new Singleton();
                     
                     // This is newer code, after I extended Singleton with
                     // a better implementation.
                     _instance = new BetterSingleton();
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

    public class ApplicationLogic
    {
        private static ApplicationLogic _instance = new ApplicationLogic();
        public static ApplicationLogic Instance { get { return _instance; } }
    
        private ApplicationLogic() { }
    }

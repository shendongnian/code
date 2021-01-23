    public class  MySingleton
    {
        private static readonly MySingleton _singtonInstance =  new MySingleton();
        private MySingleton()
        {
            
        }
        public static MySingleton SingtonInstance
        {
            get { return _singtonInstance; }
        }
    }

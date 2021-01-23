    public sealed class SomeSingleton5  
    {  
        private static SomeSingleton5 s_Instance = new SomeSingleton5();
    
        private SomeSingleton5() { }
        public static SomeSingleton5 Instance
        {
            get
            {
                return s_Instance;
           }
        }
    }

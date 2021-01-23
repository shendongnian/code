    public sealed class SomeSingleton5  
    {  
        // the compiler will generate a static constructor containing the following code 
        // and the CLR will call it (once) when SomeSingleton5 is first acccessed
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

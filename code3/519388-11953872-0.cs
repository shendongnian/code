      class Singleton 
      {
        private Singleton() { }
        private static volatile Singleton instance;
     
        public static Singleton GetInstance() 
        {
           // DoubleLock
           if (instance == null) 
           {
              lock(m_lock) {  
                 if (instance == null) 
                 { 
                    instance = new Singleton();
                 }   
              }
           }
           return instance;
        }
     
        // helper
        private static object m_lock = new object();
      }
 
 

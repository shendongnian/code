        public class MySettings{
        private static Object lockObj = new Object();
        private MySettings() {} // private .ctor
        
        private static MySettings _instance;
        
        public static MySettings MySingleSettings{
         get{
          if(_instance == null){
          lock(lockObj){
            if(_instance == null)
              _instance = new MySettings();
            }
          }
           return _instance;
        }
    }

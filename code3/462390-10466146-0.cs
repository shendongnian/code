    public class SomeSingleton {
        static _instance;
        static public SomeSingleton Instance {
            get {
                if (_instance==null) {
                    _instance=new SomeSingleton();
                }
                return _instance;
            }
        }
    }

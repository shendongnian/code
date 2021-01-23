    public sealed class SingletonExample
    {
        //static Field
        private static SingletonExample _seInstance = null;
        private int _nCounter = 0;
        
        // private constructor
        private SingletonExample() { _nCounter = 1; }
         
        //public static get(), with creating only one instance EVER
        public static SingletonExample SeInstance
        { 
            get { return _seInstance ?? (_seInstance = new SingletonExample()); }
        }      
    }

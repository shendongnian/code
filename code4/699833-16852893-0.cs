    public sealed class MySingleton 
    {
        private MySingleton() { Implementation = new MyLogic(); }
    
        public static MySingleton Instance { ... }
        private MyLogic Implementation { get; set; }
    
        ...
    }

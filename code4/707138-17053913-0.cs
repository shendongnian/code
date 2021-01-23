    class Die
    {
        public int MinNum {get;set;}
    
        public int MaxNum {get;set;}
    
        public int Roll() { 
            _lastRoll = diceRoll.Next(MinNum, MaxNum);
            return _lastRoll;
        }
        
        private int _lastRoll;
        public int LastRoll {get {return _lastRoll;}}
    
        // This Random object will be reused by all instances, which is good.
        private static readonly Random diceRoll = new Random();
    }

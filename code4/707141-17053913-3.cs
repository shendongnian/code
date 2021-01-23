    public class Die
    {
    
        // Using a constructor makes it obvious that you expect this
        // class to be initialized with both minimum and maximum values.
        public Die(int minNum, int maxNum)
        {
            // You may want to add error-checking here, to throw an exception
            // in the event that minNum and maxNum values are incorrect.
            
            // Initialize the values.
            MinNum = minNum;
            MaxNum = maxNum;
            // Dice never start out with "no" value, right?
            Roll();
        }
    
        // These will presumably only be set by the constructor, but people can
        // check to see what the min and max are at any time.
        public int MinNum { get; private set; }
    
        public int MaxNum { get; private set; }
    
        // Keeps track of the most recent roll value.
        private int _lastRoll;
    
        // Creates a new _lastRoll value, and returns it.
        public int Roll() { 
            _lastRoll = diceRoll.Next(MinNum, MaxNum);
            return _lastRoll;
        }
    
        // Returns the result of the last roll, without rolling again.
        public int LastRoll {get {return _lastRoll;}}
    
        // This Random object will be reused by all instances, which helps
        // make results of multiple dice somewhat less random.
        private static readonly Random diceRoll = new Random();
    }

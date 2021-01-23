    class RoundRobinNumber
    {
        private int _maxNumbers = 10;
        private int _lastNumber = 0;
    
        public RoundRobinNumber(int maxNumbers)
        {
            _maxNumbers = maxNumbers;
        }
    
        public int GetNextNumber()
        {
            int nextNumber = Interlocked.Increment(ref _lastNumber);
    		
            int result = nextNumber % _maxNumbers;	
    		
    		return result >= 0 ? result : -result;
        }
    }

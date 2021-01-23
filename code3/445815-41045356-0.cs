    using System;
    namespace Utils
    {
        public class RoundRobinCounter
        {
            private int _max;
            private int _currentNumber = 0;
    
            public RoundRobinCounter(int max)
            {
                _max = max;
            }
    
            public int GetNext()
            {
                uint nextNumber = unchecked((uint)System.Threading.Interlocked.Increment(ref _currentNumber));
                int result = (int)(nextNumber % _max);
                return result;
            }
        }
    }

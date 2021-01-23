    using System.Collections.Generic;
    using System.Linq;
    public class MovingAverage
    {
        private readonly Queue<decimal> _queue;
        private readonly int _period;
    
        public MovingAverage(int period)
        {
            _period = period;
            _queue = new Queue<decimal>(period);
        }
    
        public double Compute(decimal x)
        {
            if (_queue.Count >= _period)
            {
                _queue.Dequeue();
            }
            _queue.Enqueue(x);
    
            return _queue.Average();
        }
    }

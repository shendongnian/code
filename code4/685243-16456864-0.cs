    public abstract class Base
    {
        protected Timer timer = new Timer { AutoReset = false, Interval = 5000 };
        private bool _isTimedOut = false;
    
        public bool IsTimedOut { get { return _isTimedOut; } private set; }
    
        public Base()
        {
            timer.Elapsed += (o, args) => _isTimedOut = true;
        }
    
        public int Recieve(byte[] buffer) // This method cannot be overridden. It calls the TimerReset.
        {
            TimerReset();
            return InternalRecieve(buffer);
        }
    
        protected abstract int InternalRecieve(byte[] buffer); // This method MUST be overridden.
    
        private void TimerReset()
        {
            timer.Stop();
            timer.Start();
        }
    }

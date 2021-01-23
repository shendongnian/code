    class A
    {
        private double _tantheta; // add public getter
        private DateTime _lastRaise = DateTime.MinValue;
        private bool _checkBoundaries; // add public getter/setter
        public event EventHandler TanThetaWentOutOfBounds;
        public void SetTantheta(double newValue)
        {
            if(_checkBoundaries &&
                (newValue < 0.6 || newValue > 1.5))
            {
                var t = TanThetaWentOutOfBounds;
                if(t != null)
                {
                    var now = DateTime.Now;
                    if((now - _lastRaise).TotalSeconds < 3)
                    {
                        t(this, EventArgs.Empty);
                        _lastRaise = now;
                    }
                }
            }
            else
            {
                _tantheta = newValue;  
            }
        }

    class A
    {
        private double _tantheta; // add public getter
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
                    t(this, EventArgs.Empty);
                }
            }
            else
            {
                _tantheta = newValue;  
            }
        }

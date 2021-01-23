        public int Variable
        {
            get { return _variable; }
            set
            {
                yourtimer.Stop();
                IsLongerThanTooSec = false;
                _variable = value;
                yourtimer.Start();
            }
        }

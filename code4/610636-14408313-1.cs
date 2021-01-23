        public int Variable
        {
            get { return _variable; }
            set
            {
                yourtimer.Stop();
                IsLongerThanTwoSec = false;
                _variable = value;
                yourtimer.Start();
            }
        }

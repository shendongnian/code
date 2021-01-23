    bool started;
        public bool Started
        {
            get { return started; }
            set
            {
                started = value;
                if (started)
                    OnStarted(EventArgs.Empty);
            }
    
        }
    another example
    
        int positiveNumber;
    
        public int PositiveNumber
        {
            get { return positiveNumber; }
            set {
                if (value < 0)
                    positiveNumber = 0;
                else positiveNumber = value;
            }
        }

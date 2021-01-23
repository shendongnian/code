    private bool number0;
        public bool Number0
        {
            get { return number0; }
            set
            {
                number0 = value;
                NotifyPropertyChanged("Number0");
                NotifyPropertyChanged("Sum");
            }
        }
        public bool Sum
        {
            get { return this.EvaluateSum(); }
        }
        private bool EvaluateSum() 
        {
            int result = 0; 
            if (Number0) 
                result = result + 0; // Could be more complex that just addition 
            if (Number1) 
                result = result + 1; // Could be more complex that just addition 
            // Same until 9 ... 
            return result.ToString(); 
        }

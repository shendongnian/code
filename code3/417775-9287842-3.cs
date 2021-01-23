        private decimal payRate;
        public decimal PayRate
        {
            get { return payRate; }
            // i avoid use of "if else" in situations like these
            set { payRate = (value <= 7.50m) ? 7.50m : value; }
        }

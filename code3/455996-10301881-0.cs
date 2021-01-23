    // private field
        private DateTime date;
    
         
        // Public property exposes date field safely.
        public DateTime Date 
        {
            get 
            {
                return date;
            }
            set 
            {
                // Set some reasonable boundaries for likely birth dates.
                if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                {
                    date = value;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
    
        }

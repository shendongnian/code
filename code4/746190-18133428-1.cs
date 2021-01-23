    class Employee 
    {
        private Insurance insurance;
        public Insurance Insurance
        {
            get
            {
                if (insurance == null)
                {
                    insurance = new Insurance();
                }
            }
        }
     }

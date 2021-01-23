    private int Dval;
        public int DecPlaces
        {
            get { return Dval; }
            set
            {
                //DecPlaces = value;  **** This is calling set method again, hence the exception. Just comment this line
                
                if (value < 2)
                {
                    throw new ArgumentOutOfRangeException("decplaces", "decimal places minimum value should be 2.");
                }
                else this.Dval = value;
            }
        }

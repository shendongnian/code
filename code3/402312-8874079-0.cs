    // **  The Taxpayer class should be set up so that its objects are comparable to each other based on tax owed.
    class taxpayer : IComparable<taxpayer>
    {
        public int taxOwed { get; set; }
        public int income { get; set; }
        public int CompareTo(taxpayer other)
        {
            return taxOwed - other.taxOwed;
        }
    } //end taxpayer  IComparable 

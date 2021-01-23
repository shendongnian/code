    class taxpayer : IComparable<taxpayer>
    {
        public int taxOwed { get; set; }
        public int income { get; set; }
        public int CompareTo(taxpayer other)
        {
            return taxOwed - other.taxOwed;
        }
    } //end taxpayer  IComparable 

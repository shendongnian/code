You don't need to add if statements inside the CompareTo method. Return negative if the value of this is smaller and other is bigger. Return positive if the opposite is true. Return zero if they are equal. That is the case of just subtracting them from each other this.taxOwed - other.taxOwed
    class taxpayer : IComparable<taxpayer>
    {
        public int taxOwed { get; set; }
        public int income { get; set; }
        public int CompareTo(taxpayer other)
        {
            return taxOwed - other.taxOwed;
        }
    } //end taxpayer  IComparable 

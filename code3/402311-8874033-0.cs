    public class Taxpayer : IComparable<Taxpayer>
    {
        //Social Security number (use type string, no dashes between groups).  Use get and set accessors.
        string SSN
        { get; set; }
    
        int yearlyGrossIncome // Use get and set accessors.
        { get; set; }
    
        public int taxOwed  //  Use read-only accessor.
        {
            get { return taxOwed; }
        }
    
        #region IComparable<Taxpayer> Members
    
        int IComparable<Taxpayer>.CompareTo(Taxpayer other)
        {
            if (this.taxOwed > other.taxOwed)
                return 1;
            else
                if (this.taxOwed < other.taxOwed)
                    return -1;
                else
                    return 0;
        }
    
        #endregion
        //  **The tax should be calculated whenever the income is set.
        //  The Taxpayer class should have a getRates class method that has the following.
        public static void GetRates()

    public class Account
    {
        public string Name { get; private set; }
        public decimal[] MonthAmount { get; private set; }
        readonly int maxMonths = 12;
        public Account(string name, ICollection<decimal> monthAmounts)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (monthAmounts == null)
                throw new ArgumentNullException("monthAmounts");
            if (monthAmounts.Count > maxMonths)
                throw new ArgumentOutOfRangeException(string.Format(" monthAmounts must be <= {0}", maxMonths));
            this.Name = name;
    
            this.MonthAmount = new decimal[maxMonths];
            int i = 0;
            foreach (decimal d in monthAmounts)
            {
                this.MonthAmount[i] = d;
                i++;
            }
        }
    }

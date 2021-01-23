    public class Account
    {
        [NotMapped]
        public int NumberOfPayPeriods { get { return 24; } set { ... } }
        public decimal YearAmount { get; set; }
        public decimal PlanTotal
        {
            get { return NumberOfPayPeriods*YearAmount; }
        }
    }

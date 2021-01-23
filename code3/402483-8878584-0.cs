    public class FinancialYear
    {
        int yearNumber;
        private static readonly int firstMonthInYear = 4;
        public FinancialYear(DateTime forDate) 
        {
             if (forDate.Month < firstMonthInYear) {
                 yearNumber = forDate.Year + 1;
             }
             else {
                 yearNumber = forDate.Year;
             }
        }
        public override string ToString() {
            return yearNumber.ToString();
        }
    }

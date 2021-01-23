    public class FinancialYear
    {
        public YearRepresentation ResolveFinancialYear(DateTime currentDate)
        {
            YearRepresentation financialYear = new YearRepresentation();
            int year = (currentDate.Month >= 4) ? currentDate.AddYears(1).Year : currentDate.Year;
            financialYear.SetYear(year);
            return financialYear;
        }
    }
    public class YearRepresentation
    {
        public string LongYear { get; set; }
        public string ShortYear { get; set; }
        public void SetYear(int year)
        {
            this.LongYear = "Financial Year " + year;
            this.ShortYear = "FY " + year;
        }
    }

    /// <summary>
    /// Extension method to get the start of the financial year
    /// </summary>    
    public static DateTime GetStartOfFinancialYear(this DateTime date, int startMonthOfFinancialYear)
    {
        if (startMonthOfFinancialYear < 1 || startMonthOfFinancialYear > 12)
            throw new ArgumentException("Must be between 1 and 12","startMonthOfFinancialYear");
            
        DateTime rtn = new DateTime(date.Year,startMonthOfFinancialYear,1);
        if (date.Month < startMonthOfFinancialYear)
        {
            // Current FY starts last year - e.g. given April to March FY then 1st Feb 2013 FY starts 1st April 20*12*
            rtn.AddYears(-1);
        }
    
        return rtn;
    }
    // Example, Financial Year starts in July
    DateTime startFY = DateTime.Now.GetStartOfFinancialYear(7);
    DateTime endFY = startFY.AddYears(1).AddDays(-1);

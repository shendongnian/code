    public DateTime GetStartOfFinancialQtr(DateTime dtGiven, int startMonth) {
        DateTime dtQuarter = new DateTime(dtGiven.Year, startMonth, 1);
        // Start Q is less than the given date
        if(startMonth > dtGiven.Month) {
            while(dtQuarter > dtGiven) {
                dtQuarter = dtQuarter.AddMonths(-3);
            }
        }
        // Start Q is larger than the given date
        else {
            while(dtQuarter.Month + 3 <= dtGiven.Month) {
                dtQuarter = dtQuarter.AddMonths(3);
            }
        }
        return dtQuarter;
    }

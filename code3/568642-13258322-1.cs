    public int CalcTime(double AnnualIncome, int Time, double Value)
    {
        while (AnnualIncome / 12 <= Value / Time) 
        {
            Time++;
        }
        return Time;
    }

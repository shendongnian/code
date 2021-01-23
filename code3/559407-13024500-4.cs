    public static int GetDifferenceInDaysX(this DateTime startDate, DateTime endDate)
        {
            TimeSpan ts = endDate - startDate;
            int totalDays = (int) Math.Ceiling(ts.TotalDays);
            if (ts.TotalDays < 1 && ts.TotalDays > 0)
                totalDays = 1;
            else
                totalDays = (int) (ts.TotalDays);
            return totalDays;
        }

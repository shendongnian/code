    private int GetSeason(DateTime date)
    {
        //using decimal to avoid any inaccuracy issues
        decimal value = date.Month + date.Day / 100M;   // <month>.<day(2 digit)>
        if (value < 3.21 || value >= 12.22) return 3;   // Winter
        if (value < 6.21) return 0; // Spring
        if (value < 9.23) return 1; // Summer
        return 2;   // Autumn
    }
    private string ConvertSeason(int value)
    {
        switch (value)
        {
            case 0:
                return "'Spring'";
            case 1:
                return "'Summer'";
            case 2:
                return "'Autumn'";
            case 3:
                return "'Winter'";
        }
        return "";
    }

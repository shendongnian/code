    public string HolidaysText
    {
        get
        {
            if (AccumHolidays.ToString() != "")
                return AccumHolidays.ToString();
            if (Holidays.ToString() != "")
                return Holidays.ToString();
            return "0";
        }
    }

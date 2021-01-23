    private int? dayOrderInt;
    public int? DayOrderInt
    {
         get { return dayOrderInt; }
         set { if (value < 1 || value > 7) throw new ArgumentException(string.Format("{0} is an invalid day of the week", value)); dayOrderInt = value; }
    }
    public RSSCalendarRuleDay? DayOrder
    {
        get { if (DayOrderInt.HasValue) return (RSSCalendarRuleDay)DayOrderInt; return null; }
    }

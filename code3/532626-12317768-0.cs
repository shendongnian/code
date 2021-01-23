    public int? DayOfWeekValue { get; set; }
    [NotMapped]
    public DaysOfWeek DayOfWeek
    {
        get { return (DaysOfWeek)DayOfWeekValue; }
        set { DayOfWeekValue= (int)value; }
    }

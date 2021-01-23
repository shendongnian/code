    public RSSCalendarRuleDay DayOrder { get; set; }
    
    ...
    
    RSSCalendarDay xx = new RSSCalendarDay(...)
    xx.DayOrder = (DayOrder)4;	// Will set WE for the DayOrder property
    
    ...
    
    // If you need to get the value as an int
    int dayOrderAsInt = (int)xx.DayOrder;
	
	// Still possible to affect invalid values however
	RSSCalendarRuleDay z = (RSSCalendarRuleDay)8;
	// So if you want to check for int validity:
	if (Enum.IsDefined(typeof(RSSCalendarRuleDay), dayOrderAsInt))
	{
		// If we're here, the value is valid !
	}

    public static class CalendarFrom
    {
        public static DateTime SelectedFrom { get; set; }
    }
    
    public static class CalendarTo
    {
        public static DateTime SelectedDate { get; set; }
    }
    
    DateTime? startDate = CalendarFrom.SelectedFrom;
                DateTime? endDate = CalendarTo.SelectedDate;
    
                if (startDate.HasValue 
                    && ( startDate.Value != DateTime.MaxValue || startDate.Value != DateTime.MinValue))
                {
                }

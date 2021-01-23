    private void datePicker_Loaded(object sender, RoutedEventArgs e)
    {
    	DatePicker picker = sender as DatePicker;
    
    	if (picker.DisplayDateStart == null || picker.DisplayDateEnd == null) return;
    	
    	picker.BlackoutDates.Clear();
    
    	DateTime start = picker.DisplayDateStart.Value;
    	DateTime end = picker.DisplayDateEnd.Value;
    
    	while (start <= end)
    	{
    		if (!availableDates.Contains(start))
    		{
    			picker.BlackoutDates.Add(new CalendarDateRange(start, start));
    		}
    		start = start.AddDays(1);
    	}
    }

    void DateRotate(IEnumerable<DateTime> datesList, int rotation, out List<DateTime> listA, out List<DateTime> listB)
    {
    	listA = new List<DateTime>();
    	listB = new List<DateTime>();
    	
    	var weeks = datesList.GroupBy(d =>
    		CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, DayOfWeek.Monday)).ToList();
    	
    	var c_rotation = 0;
    	var c_list = listA;
    	
    	using (var en = weeks.GetEnumerator())
    		while(en.MoveNext())
    		{
    			c_list.AddRange((IGrouping<int, DateTime>)en.Current);
    			c_rotation++;
    			if (c_rotation == rotation)
    			{
    				c_rotation = 0;
    				c_list = c_list == listA ? listB : listA;
    			}
    		}
    }

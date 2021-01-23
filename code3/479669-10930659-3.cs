    public class BusinessDays
    {
    	private HashSet<DateTime> holidaySet;
    	public ReadOnlyCollection<DayOfWeek> WeekendDays{get; private set;}
    	
    	public BusinessDays(IEnumerable<DateTime> holidays, IEnumerable<DayOfWeek> weekendDays)
    	{
    		WeekendDays = new ReadOnlyCollection<DayOfWeek>(weekendDays.Distinct().OrderBy(x=>x).ToArray());
    		if(holidays.Any(d => d != d.Date))
    			throw new ArgumentException("holidays", "A date must have time set to midnight");
    		holidaySet = new HashSet<DateTime>(holidays);
    	}
    	
    	public BusinessDays(IEnumerable<DateTime> holidays)
    		:this(holidays, new[]{DayOfWeek.Saturday, DayOfWeek.Sunday})
    	{
    	}
    	
    	public bool IsWeekend(DayOfWeek dayOfWeek)
    	{
    		return WeekendDays.Contains(dayOfWeek);
    	}
    	
    	public bool IsWeekend(DateTime date)
    	{
    		return IsWeekend(date.DayOfWeek);
    	}
    	
    	public bool IsHoliday(DateTime date)
    	{
    		return holidaySet.Contains(date.Date);
    	}
    	
    	public bool IsBusinessDay(DateTime date)
    	{
    		return !IsWeekend(date) && !IsHoliday(date);
    	}
    	
    	public DateTime AddBusinessDays(DateTime date, int days)
    	{
    		if(!IsBusinessDay(date))
    			throw new ArgumentException("date", "date bust be a business day");
    		int sign = Math.Sign(days);
    		while(days != 0)
    		{
    			do
    			{
    			  date.AddDays(sign);
    			} while(!IsBusinessDay(date));
    			days -= sign;
    		}
    		return date;
    	}
    }

    public class DateComparer : IEqualityComparer<DateTime>
    {
    	public bool Equals(DateTime left, DateTime right)
    	{
    	    return left.Date.Equals(right.Date);
    	}
    	
    	public int GetHashCode(DateTime dateTime)
    	{
    	    return dateTime.Date.GetHashCode();
    	}
    }

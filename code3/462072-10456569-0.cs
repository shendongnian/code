    public class MyScheduler : VirtualTimeScheduler<DateTime, TimeSpan>
    {
    	protected override DateTime Add(DateTime abs, TimeSpan rel)
    	{
    		return abs.Add(rel);
    	}
    	
    	protected override DateTimeOffset ToDateTimeOffset(DateTime abs)
    	{
    		return new DateTimeOffset(abs);
    	}
    	
    	protected override TimeSpan ToRelative(TimeSpan rel)
    	{
    		return rel;
    	}
    }

    public class TechDay
    {
    	public Session MorningSlot { get; set; }
    	public Session EveningSlot { get; set; }
    
    	public TechDay(IEventConfigurator morningConfigurator, IEventConfigurator eveningConfigurator)
    	{
    		MorningSlot = new Session();
    		morningConfigurator.Configure(MorningSlot);
    
    		EveningSlot = new Session();
    		eveningConfigurator.Configure(EveningSlot);
    	}
    }
    
    public interface IEventConfigurator
    {
    	void Configure(Session session);
    }
    
    public class Session
    {
    	public static DateTime StartTime { get; set; }
    	public static DateTime EndTime { get; set; }
    }
    
    public class FromStringEventConfigurator : IEventConfigurator
    {
    	private readonly string _begin;
    	private readonly string _end;
    
    	public FromStringEventConfigurator(string begin, string end)
    	{
    		_begin = begin;
    		_end = end;
    	}
    
    	public void Configure(Session session)
    	{
    		CultureInfo provider = CultureInfo.InvariantCulture;
    		Session.StartTime = DateTime.ParseExact(_begin, "h:mm tt", provider);
    		Session.EndTime = DateTime.ParseExact(_end, "h:mm tt", provider);
    		// ...
    	}
    }

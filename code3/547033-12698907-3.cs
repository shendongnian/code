    public class EvilBatchLogger : BatchLoggerBase
    {
    	public EvilBatchLogger()
    		: base(new object())
    	{
    	
    	}
    }
    
    var evil1 = new EvilBatchLogger();
    var evil2 = new EvilBatchLogger();

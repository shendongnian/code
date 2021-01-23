    public sealed class Helper
    {
    	private Helper()
    	{
    	}
    
    	public static string GetBayrueConnectionString()
    	{
    	    return DAL.Properties.Settings.Default.BayrueConnectionString;
    	}
    }

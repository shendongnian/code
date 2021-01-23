    static class YourContextExtensions
    {
    	public static IQueryable<YourView>(this YourContext context)
    	{
    		return context.Database.SqlQuery<YourView>("select * from dbo.YourView");
    	}
    

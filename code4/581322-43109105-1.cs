    static class YourContextExtensions
    {
    	public static IQueryable<YourView>(this YourContext context)
    	{
    		return this.Database.SqlQuery<YourView>("select * from dbo.YourView");
    	}
    

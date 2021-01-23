    class YourContext
    {
    	public IQueryable<YourView> YourView 
    	{
    		get
    		{
    			return this.Database.SqlQuery<YourView>("select * from dbo.YourView");
    		}
    	}
    }

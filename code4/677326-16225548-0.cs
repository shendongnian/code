    public class MVCDatabase : DbContext
	{
		public MVCDatabase() : base(ConfigurationManager.AppSettings["ConnectionString"])
		{
		}
        ...
    }

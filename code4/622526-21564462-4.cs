    public partial class MyDb1 : DbContext
	{
		public MyDb1()
			: base("name=MyDb1Connection")
		{
			Database.SetInitializer<Models.MyDb1>(null);
		}
		
		...
	}

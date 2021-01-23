	using BaseContext = BaseLibrary.MyContext;
	public class MyExtendedContext : BaseContext
	{
		public override DbSet<Person> Persons { get; set; }
	}

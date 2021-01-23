	public class MyDialect : MsSql2008Dialect
	{
		public MyDialect()
		{
			RegisterFunction("len", new StandardSafeSQLFunction("len", NHibernateUtil.Int32, 1));
		}
	}

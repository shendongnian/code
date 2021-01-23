	public class DbTests
	{
		public string code = "123";
		public void Test1()
		{
			Db db = new Db();
			Tag selectedTag = db.Select(tag => tag.Code == code);
		}
	}

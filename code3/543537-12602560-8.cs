	public class DbTests
	{
		public void Test1()
		{
			Db db = new Db();
			Tag selectedTag = db.Select((Predicate<Tag>) TestTag);
		}
		private bool TestTag(Tag tag)
		{
			return tag.Code == "123";
		}
	}

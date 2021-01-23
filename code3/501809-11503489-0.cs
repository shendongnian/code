	public class DatabaseService : IDatabaseService
	{
		public IEnumerable<User> 
		{
			get
			{
				using (var db = new DataContext())
				{
					return db.Users.Where(rec => !rec.IsDeleted)
				}
			}
		}
	}

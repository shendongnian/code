	public class DatabaseService : IDatabaseService
	{
		public IEnumerable<User>  GetUsers(someconditions)
		{
			using (var db = new DataContext())
			{
				return db.Users.Where(rec => !rec.IsDeleted
				&& someconditions).ToList();
			}
		}
	}

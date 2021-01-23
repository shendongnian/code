	public class DatabaseService : IDatabaseService
	{
		public IEnumerable<User>  GetUsers(someconditions)
		{
			// someconditions can be any kind of condition to include in the query
			using (var db = new DataContext())
			{
				return db.Users.Where(rec => !rec.IsDeleted
				&& someconditions).ToList();
			}
		}
		
		[...] implement stuff like DeleteUser(guid), UpdateUser(User user))
	}

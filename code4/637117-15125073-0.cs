	public IEnumerable<User> Get()
	{
		using (var db = new MyContext())
		{
			return (from u in db.Users
				    orderby u.FirstName
				    select Mapper.Map(u)).AsEnumerable();
		}
	}

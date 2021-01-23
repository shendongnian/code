	public bool IsUser(string username)
	{
		using (var entities = new datingEntities())
		{
			return entities.Person.Any(p => p.Username == username);
		}
	}

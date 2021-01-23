	public void SomeMethod()
	{
		var listA = GetList("DataContext.ViewA");
		var listB = GetList("DataContext.ViewB");
		var listC = GetList("DataContext.ViewC");
	}
	public List<EntityObject> GetList(string dataContextName)
	{
		return (from x in GetSpecificSource(dataContextName)
			   where //Rest of where clause
			   select x).ToList();
	}
	
	public IEnumerable<MyType> GetSpecificSource(string dataContextName)
	// Or: public IQueryable<MyType> GetSpecificSource(string dataContextName)
	{
		// ToDo: Return the correct source depending on the name. E.g.:
		switch(dataContextName)
		{
			case "DataContext.ViewA":
				return DataContext.ViewA;
			case "DataContext.ViewB":
				return DataContext.ViewB;
			case "DataContext.ViewC":
				return DataContext.ViewC;
		}
	}

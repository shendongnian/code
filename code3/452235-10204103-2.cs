    string Name;
	string Street;
	string Code;
	string Province;
	var query=(from t in Model select t);
	if(Name!=null)
	{
		query=query.Where (q =>q.Name==Name);
	}
	if(Street!=null)
	{
		query=query.Where (q =>q.Street==Street);
	}
	if(Code!=null)
	{
		query=query.Where (q =>q.Code==Code);
	}
	if(Province!=null)
	{
		query=query.Where (q =>q.Province==Province);
	}
	List<Query> ls = query.ToList();

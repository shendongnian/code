    protected List<A> Proccess(int count, int id)
    {
    	var query = session.Query<A>();  
        Func<IQueryable<A>, IQueryable<A>> addNesting = q.Select(x => x.ParentA);
    	foreach(var i in Enumerable.Range(0, count))
    	{
    	    query = addNesting(query);
    	}
        
    
    	return query.Where(x => x.Id == id).ToList();
    }

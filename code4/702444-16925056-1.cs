    protected List<A> Proccess(int count, int id)
    {
    	var query = session.Query<A>()
                  .Select(x => new Pair { Item = x, Ancestor = x };  
        Func<IQueryable<Pair>, IQueryable<Pair>> addNesting 
                  = q.Select(x => new Pair{ Item = x.Item, Ancestor = Ancestor.Parent });
    	foreach(var i in Enumerable.Range(0, count))
    	{
    	    query = addNesting(query);
    	}
        
    
    	return query.Where(x => x.Ancestor == id).Select(x => x.Item).ToList();
    }
    private class Pair
    {
       public A Item {get;set;}
       public A Ancestor { get; set; }
    }

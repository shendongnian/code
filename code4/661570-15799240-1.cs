    string permalink ="computers1/hp/computers2"; 
    var aliases = permalink.Split('/');
	
    var query = dc.Categories.Where(r=>r.Alias == aliases[aliases.Length-1])
                  .Select(r=> new Info { category = r,  recordID = r.ParentID});
		
		for(int i = aliases.Length -2 ; i >= 0; i--)
		{
			string alias = aliases[i]; 
			query =  query.Join(dc.Categories , 
                                a => a.recordID , b => b.Id , (a,b) => new { a , b} )
			.Where(r=>r.b.Alias == alias)
			.Select(r=> new Info { category = r.a.category, recordID = r.b.ParentID});
		}
	
		return query.SingleOrDefault().category;
		

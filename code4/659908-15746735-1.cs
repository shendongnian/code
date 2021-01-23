    var mainQuery = session.Query<Employee>();
    
    GetData(mainQuery, e => new { e.Name, e.Address });
    //object is used because you create anonymous objects and pass them around
    public DataTable GetData(IQueryable query, 
                             Expression<Func<Employee, object>> selector)
    {
        return query.OrderBy(e => e.Age)
    	            .Select(selector)
    	            //...
    }

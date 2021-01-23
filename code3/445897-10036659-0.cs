    var ctx = new Context();
    IQueryable<Users> consulta = ctx.Users;
    
    if ( filters.Count > 0 )
       query = query.Where( p => filters.Any(x=>x.Contains(p.Name)) || 
                                 filters.Any(x=>x.Contains(p.LastName)) );

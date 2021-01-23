    var query = context.P_List;
    
    if(filter.zs != null && filter.zs.Count != 0)
     query = query.Where(p => filter.zs.Contains<int>(p.z));
    
    if(filter.ys != null && filter.ys.Count != 0)
     query = query.Where(p => filter.ys.Contains<int>(p.y));
    
    if(filter.as != null && filter.as.Count != 0)
     query = query.Where(p => (from ac in context.a_child where filter.as.Contains(ac) select a).Contains(p.a_child));
    
    //and the same for v2...
    var list = query.ToList(); //execute the SQL

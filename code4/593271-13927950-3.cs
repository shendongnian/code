    var groupQuery = ent.MyTable.GroupBy(r => r.F0000 );
    IEnumerable<Result> query;
    
    switch(Period)
    { 
        case 1:
            query = groupQuery.Select(grp => new Result { 
                  F008 = grp.Sum(r => r.F008),
                  F009 = grp.Sum(r => r.F009_1 + r.F009_2)
               };
            break;
        case 2:
            query = groupQuery.Select(grp => new Result { 
                  F008 = grp.Sum(r => r.F008),
                  F009 = grp.Sum(r => r.F009_3 + r.F009_4)
               };
            break;
        case 3:
            query = groupQuery.Select(grp => new Result { 
                  F008 = grp.Sum(r => r.F008),
                  F009 = grp.Sum(r => r.F009_5 + r.F009_6)
               };
            break;
        case 4:
            query = groupQuery.Select(grp => new Result { 
                  F008 = grp.Sum(r => r.F008),
                  F009 = grp.Sum(r => r.F009_7 + r.F009_8)
               };
            break;
    }
    
    var MyCalculation = query.ToList();

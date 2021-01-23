    var query = from fm in dbContext.FamilyMen
                join bm in dbContext.BusinessMen on 
                    bm.name equals fm.name and bm.color equals fm.color
                select new {
                   FamilyMan = fm,
                   BusinessMan = bm
                };
     
    var resultList = query.ToList();

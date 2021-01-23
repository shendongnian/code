    var query = from fm in dbContext.FamilyMen
                join bm in dbContext.BusinessMen on 
                    new { bm.name, bm.color } equals new { fm.name, fm.color }
                select new {
                   FamilyMan = fm,
                   BusinessMan = bm
                };
     
    var resultList = query.ToList();

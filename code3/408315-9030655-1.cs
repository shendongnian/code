    var leftJoin=(
    					from Table2 in db.Table2
    					join Table3 in db.Table3
    						on Table2.ID equals Table3.Table2ID 
    					group Table3 by Table3.Table1ID into g
    					select new
    					{
    						Table1ID=g.Key,
    						SumOf= g.Sum (x =>x.Field1 )
    					}
    				);
    var output=(
    		from Table1 in db.Table1
    		from g in leftJoin
    			.Where (a =>a.Table1ID==Table1.ID).DefaultIfEmpty()
    		select new
    		{
    			Table1.ID,
    			SumOf=(g.SumOf??0)-Table1.Field1
    		}
    	);

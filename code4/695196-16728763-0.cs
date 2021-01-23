    var myData = ds.Tables[0].AsEnumerable().Select(r => new {
        column1 = r.Field<string>("FormId")       
    });
    var list = myData.ToList(); 
    
    
    var myData2 = ds.Tables[1].AsEnumerable().Select(r => new {
        column1 = r.Field<string>("TabId"),
        
    });
    
    var list2 = myData2 .ToList();

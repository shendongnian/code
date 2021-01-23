    var result = entity.TblSayacOkumalari 
                       .Select(x => new  
                       { 
                           Date = x.date, 
                           TotalUsage = x.total_usage_T1,
                           UsageType = "T1"
                       }) 
                       .Union(entity.TblSayacOkumalari.Select(x => new  
                       { 
                           Date = x.date, 
                           TotalUsage = x.total_usage_T2,
                           UsageType = "T2"
                       })); 

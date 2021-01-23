        IEnumerable<TblSayacOkumalari> sayac_okumalari = 
       entity.TblSayacOkumalari
         .Select(x => new
              {     
                    date= x.date, 
                    TotalUsageValue = x.total_usage_T1,
                    UsageType     = "T1" 
               })
         .Concat(entity.TblSayacOkumalari
          .Select(x => new
              { 
                    date= x.date,
                    TotalUsageValue =  x.total_usage_T2, 
                    UsageType     = "T2" }
       )); 

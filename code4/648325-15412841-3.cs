    List<DateTime> GetDateRange(List<LockedDate> source, DateTime start, DateTime end)
    {
                   
           List<DateTime> dt = new List<DateTime>();
           foreach(LockedDate d in source)
           {
                 if(!d.IsYearly)
                 {
                      if(start<=d.Date && d.Date<=end)
                           dt.Add(d.Date);
                 }
                 else
                 {
                      for(DateTime i = new DateTime(start.Year,d.Date.Month,d.Date.Day);i<=new DateTime(end.Year,d.Date.Month,d.Date.Day);i=i.AddYears(1))
                      {
                            dt.Add(i);
                      }
                 }
        
          }
          return dt;
    }

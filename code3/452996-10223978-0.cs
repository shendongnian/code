    List<DateTime> lstdt = new List<DateTime>() {
                    new DateTime(2010,5,5,1,10,0),
                    new DateTime(2011,5,5,2,10,0),
                    new DateTime(2010,8,5,1,10,0),
                    new DateTime(2010,5,5,1,10,0),
                    new DateTime(2011,11,5,1,10,0),
                    new DateTime(2010,12,5,1,10,0),
                };            
    
    double maxval = lstdt.Max(c => c.TimeOfDay.TotalMinutes);
    List<double> lstpercent = lstdt.Select(d1 => d1.TimeOfDay.TotalMinutes/maxval *100.00).ToList<double>();

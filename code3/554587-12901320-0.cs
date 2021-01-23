    var manader = from c in db.nys
                  group c by c.S_Month into g
                  select new { 
                        Month = g.Key, 
                        Overtimes = g.Sum(x => Int32.Parse(x.S_Overtime)),
                        WorkingTimes = g.Sum(x => Int32.Parse(x.S_WorkingTime)) 
                  };
                         

    var grouped = memberSelectedTiers.AsEnumerable()
                                     .GroupBy(r => r.Field<int>("EmpId"))
                                     .Select(grp => 
                                         new { 
                                             EmpId = grp.Key
                                           , MaxDate = grp.Max(e => e.Field<DateTime>("Insert_Date"))
                                         });

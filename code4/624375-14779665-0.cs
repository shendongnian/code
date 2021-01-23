    var grouped = memberApprovedTiers.AsEnumerable()
                                     .GroupBy(r => r.Field<int>("EmpId"))
                                     .Select(grp => 
                                         new { 
                                             EmpId = gr.Key
                                           , MaxDate = grp.Max(e => e.Field<DateTime>("Insert_Date"))
                                         });

     var test = (from sp in dataTables
                 where (sp.NewClient == true) &&
                       (sp.DateAssistanceRequested >= new DateTime(2013, 1, 1) &&
                        sp.DateAssistanceRequested <= new DateTime(2013, 2, 1)) &&
                       (sp.DateFinished > new DateTime(2013, 2, 1))
                 group sp by sp.PriorityRow != null 
                                   ? sp.PriorityRow.PriorityKey 
                                   : "not key"
                          into groupz
                 select new { Key = groupz.Key, sount = groupz.Count() });

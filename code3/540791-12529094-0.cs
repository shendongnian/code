    var results = from r1 in table.AsEnumerable()
                  join r2 in comment.AsEnumerable()
                  on new {
                            signal=r1.Field<string>("SignalName"), 
                            message=r1.Field<int?>("MessageID")
                   } 
                  equals new {
                            signal=r2.Field<string>("SignalName"), 
                            message=r2.Field<int?>("MessageID")
                  } into prodGroup
                  from r3 in prodGroup.DefaultIfEmpty();

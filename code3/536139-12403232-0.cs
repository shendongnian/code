    from dt1 in dsResults.Tables[0].AsEnumerable()
    join dt2 in dsResults.Tables[1].AsEnumerable()
    on dt1 .Field<decimal>("RecordId") equals dt2.Field<decimal>("RecordId2")
     select new
     {
       Property1 = dt1 .Field<decimal>("RecordId"),
       Property2 = dt2 .Field<decimal>("RecordId2")
       ...... 
      
      }
    ;
 

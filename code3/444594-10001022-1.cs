    DataTable dt = GetDataTableResults();
    var results = from row in dt.AsEnumerable()
                  group row by new { EventDate = row.Field<DateTime>("EventTime").Date } into rowgroup
                  select new
                  {
                      EventDate = rowgroup.Key.EventDate,
                      ValueOne = rowgroup.Sum(r => r.Field<int>("ValueOne")),
                      ValueTwo = rowgroup.Average(r => r.Field<decimal>("ValueTwo"))
                  };  

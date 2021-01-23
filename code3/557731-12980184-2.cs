    var resultQuery = from r in query.AsEnumerable()
                      let d = TryGetDate(r.Field<string>("Value"))
                      where (r.Field<string>("Label") == Label &&
                          d != null && 
                          d.Month == 10)
                      select r.Field<int>("PID");
    private DateTime? TryGetDate(string value)
    {
        DateTime d;
        return DateTime.TryParse(value, out d) ? d : default(DateTime?);
    }

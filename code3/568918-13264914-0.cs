    // This assumes you want the *local* year. Is that right? Think about time zones
    // around the turn of the year...
    int year = DateTime.Today.Year; 
    var dates = dateTypeList.Rows.AsEnumerable()
                            .Select(row => new DateTime(year,
                                                        row.Field<int>("Month"),
                                                        row.Field<int>("Day")))
                            .ToList();

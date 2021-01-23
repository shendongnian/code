    DateTime dateStart = new DateTime(2012, 1, 1);
    DateTime dateEnd = new DateTime(2013, 7, 1);
    int year = DateTime.Today.Year; 
    var results = dateTypeList.Rows.AsEnumerable()
                            .Select(row => new DateTime(year,
                                                        row.Field<int>("Month"),
                                                        row.Field<int>("Day")))
                            .Where(x => x >= dateStart && x <= dateEnd)
                            .ToList();

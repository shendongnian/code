    List<string> years   = dataSet.Tables[0].AsEnumerable()
                                .Select(r => r.Field<string>(0))
                                .ToList();
    List<double> doubles = dataSet.Tables[0].AsEnumerable()
                                .Select(r => r.Field<double>(1))
                                .ToList();

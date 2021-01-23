    private DataTable CreateSummaryFocusOfEffortData(List<int> yourList)
    {
        var result = ReportData.AsEnumerable()
            .GroupBy(row => new
                                {
                                    Value = row.Field<string>("Value"),
                                    Description = row.Field<string>("Description")
                                })
            .Select(g =>
                        {
                            var row = g.First();
                            row.SetField("Hours", 
                                         g.Where(r=>yourList.Contains(r.Field<int>("Id")))
                                          .Sum(r => r.Field<double>("Hours")));
                            return row;
                        });
      return result.CopyToDataTable();
    }

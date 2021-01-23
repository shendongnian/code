    public static CSVData CreateCSVData(List<RegDataDisplay> rList,
                                        string[] selectors)
    { 
        CSVData csv = new CSVData();
        foreach (string selector in selectors)
        {
            var property = typeof(RegDataDisplay).GetProperty(selector);
            var values = rList.Select(row => (string) property.GetValue(rList, null))
                              .ToList();
            csv.Columns.Add(values);
        }
    }

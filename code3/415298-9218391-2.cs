    public static CSVData CreateCSVData(List<RegDataDisplay> rList,
                                        string[] selectors)
    { 
        CSVData csv = new CSVData();
        foreach (string selector in selectors)
        {
            var prop = typeof(RegDataDisplay).GetProperty(selector);
            var values = rList.Select(row => (string) prop.GetValue(row, null))
                              .ToList();
            csv.Columns.Add(values);
        }
    }

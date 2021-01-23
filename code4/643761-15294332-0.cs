    private static DataTable ToDictionary(List<Dictionary<string, int>> list)
    {
        DataTable result = new DataTable();
        if (list.Count == 0)
            return result;
    
        result.Columns.AddRange(
            list.First().Select(r => new DataColumn(r.Key)).ToArray()
        );
    
        list.ForEach(r => result.Rows.Add(r.Select(c => c.Value).Cast<object>().ToArray()));
    
        return result;
    }

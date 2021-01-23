    foreach (PropertyInfo p in type.GetProperties())
    {
        if (!_ordinalMap.ContainsKey(p.Name))
        {
            DataColumn dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                // do not provide column type
                : table.Columns.Add(p.Name); 
    
            _ordinalMap.Add(p.Name, dc.Ordinal);
        }
    }

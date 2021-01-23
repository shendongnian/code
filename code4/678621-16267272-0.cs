    IEnumerable<int?> positionValues = myDataSet.Tables["Table"].AsEnumerable()
        .Select(r => r.Field<int?>(1));
    IEnumerable<string> positions = positionValues 
        .Select(v => v.HasValue ? v.Value.ToString() : "null");
    string positionDV = string.Join(", ", positions);
    

    string frmt = "";
    int columnCount = 0;
    var values = new List<string>();
    foreach (DataColumn co in DT.Columns)
    {
        values.Add(co.ColumnName);
        frmt += string.Format("{0}{2}, -30{1}", "{", "}", columnCount);
        columnCount++;
    }
    string str = string.Format(frmt, values.ToArray());

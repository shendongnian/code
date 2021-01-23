    string str = "";
    string frmt = "";
    var values = new List<string>();
    foreach (DataColumn co in DT.Columns)
    {
        values.Add(co.ColumnName);
        frmt += "{0,-30}";
    }
    str = String.Format(frmt, values.ToArray());

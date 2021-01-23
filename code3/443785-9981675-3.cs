    var inDT = new DataTable();
    // Fill the input table
    
    var oDT = new DataTable();
    var dfq = new Dictionary<DateTime, DataRow>;
    oDT.Columns.Add("StartDateTime", typeof(DateTime));
    for (int i = 0; i < inDT.Rows.Count; i++) {
        var key = (DateTime)inDT.Rows[i][0];
        var row = (String)inDT.Rows[i][2];
        var data = (Double)inDT.Rows[i][1];
    
        if (!oDT.Columns.Contains(row)) {
           oDT.Columns.Add(row);
        }
        if (dfq.ContainsKey(key)) {
            dfq[key][row] = data;
        } else {
            var oRow = oDT.NewRow();
            oRow[0] = key;
            oRow[row] = data;
            dfq.Add(key, oRow);
            oDT.Rows.Add(oRow);
        }
    }
    // pivot table in oDT

    Datatable1.Columns.Add("city", typeof(string));
    Datatable1.Columns.Add("country", typeof(string));
    
    for (int i = 0; i < Datatable1.Rows.Count; i++)
    {
        Datatable1.Rows[i][2] = ConvertSafe.ToString(DataTable2[i][0], "");
        Datatable1.Rows[i][3] = ConvertSafe.ToString(DataTable2[i][1], "");
    }

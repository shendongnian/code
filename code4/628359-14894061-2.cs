    Datatable1.Columns.Add("city", typeof(string));
    Datatable1.Columns.Add("country", typeof(string));
    
    for (int i = 0; i < Datatable1.Rows.Count; i++)
    {
        Datatable1.Rows[i][2] = DataTable2.Rows[i][0].toString();
        Datatable1.Rows[i][3] = DataTable2.Rows[i][1].toString();
    }

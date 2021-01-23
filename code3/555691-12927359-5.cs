    OleDbCommand ccmd = new OleDbCommand(@"Select * From [SPAT$]", conn);
    OleDbDataAdapter da = new OleDbDataAdapter(ccmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    
    for (int i = 19; i < dt.Rows.Count; i++)
    {
        var value = dt.Rows[i][3].ToString(); // here 3 refers to column 'C'
    }
    dataGridView1.DataSource = dt.AsEnumerable()
                              .Where((row, index) => index >= 19)
                              .CopyToDataTable();

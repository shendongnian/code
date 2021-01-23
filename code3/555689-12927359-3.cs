    OleDbCommand ccmd = new OleDbCommand(@"Select * From [SPAT$]", conn);
    OleDbDataAdapter da = new OleDbDataAdapter(ccmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    
    for (int i = 19; i < dt.Rows.Count; i++)
    {
        var value = dt.Rows[i]["C"].ToString();
    }
    dataGridView1.DataSource = dt.AsEnumerable().Where((row, index) => index > 3).CopyToDataTable();

    SqlCommand cmd  = new System.Data.SqlClient.SqlCommand(sql, _conn);
    SqlDataReader rdr = cmd.ExecuteReader();
    System.Data.DataTable tbl = new System.Data.DataTable("Results");
    tbl.Load(rdr);
    
    if (tbl.Rows.Count > 0)
       Name.Text = tbl.Rows[0]["column_name"].ToString();

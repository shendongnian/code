    SqlConnection con = new SqlConnection("Initial Catalog=test;Data Source=test;user id=sa;password=****;");
    DataTable dt = new DataTable();
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter("select * from table1", con);
    
    da.Fill(dt);
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        DataRow row = dt.Rows[i];
        int? ii;
        if (row["iiColumnName"] is DBNull)
            ii = null;
        else
            ii = (int)row["iiColumnName"];
        if (ii != null)
            test.Text = ii.ToString() + "Test";
        else
            test.Text = "ii is not set";
    }

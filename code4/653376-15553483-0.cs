    SqlConnection con = new SqlConnection("Initial Catalog=test;Data Source=test;user id=sa;password=****;");
    DataTable dt = new DataTable();
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter("select * from table1", con);
    
    da.Fill(dt);
    
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        DataRow row = dt.Rows[i];
        if (row["iiColumnName"] is DBNull)
        {
            test.Text = "ii is not set";
        }
        else
        {
            int ii = Convert.ToInt32(row["iiColumnName"]);
            test.Text = ii.ToString() + "Test";
        }
    }

    public void ListCat()
    {
        DataTable linkcat = new DataTable("linkcat");
        using (SqlConnection sqlConn = new SqlConnection(@"Connection stuff;"))
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT LastName FROM list WHERE LastName <> 'NULL'", sqlConn))
            {
                da.Fill(linkcat);
            }
        }
        foreach (DataRow da in linkcat.Rows)
        {
            comboBox1.Items.Add(da[0].ToString());
        }
    }

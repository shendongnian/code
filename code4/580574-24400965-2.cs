    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = "data source=CHANCHAL\SQLEXPRESS;initial catalog=AssetManager;user id=GIPL-PC\GIPL;password=";
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter("select * from detail1", con);
        SqlCommandBuilder cmdbl = new SqlCommandBuilder(ad);
        DataSet ds = new DataSet("detail1");
        ad.Fill(ds, "detail1");
        DataRow row = ds.Tables["detail1"].NewRow();
        row["Name"] = textBox1.Text;
        row["address"] =textBox2.Text;
        ds.Tables["detail1"].Rows.Add(row);
        ad.Update(ds, "detail1");
        con.Close();
        MessageBox.Show("insert secussfully"); 
    }

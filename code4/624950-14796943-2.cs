    using (var cmd = new SqlCommand("INSERT INTO barcode (bcd) VALUES (@bcd)", con))
    {
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@bcd", SqlDbType.NChar, 20,"bcd").Value = textBox1.Text;
        cmd.ExecuteNonQuery();
    }
    SqlDataAdapter ada = new SqlDataAdapter();
    //ada.SelectCommand = new SqlCommand("select * from barcode", con);
    ada.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        
    ada.SelectCommand = new SqlCommand("select bcd from barcode", con);
    DataSet ds = new DataSet();
    ada.Fill(ds, "barcode");
    dataGridView1.DataSource = ds.Tables[0].DefaultView;

    DataTable table= new DataTable("table");
    using (SqlConnection sqlConn = new SqlConnection(@"Your Connection Stuff;"))
    {
    if (radioButton1.Checked == true)
    {
    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM yourdatabase WHERE date = " + date, sqlConn))
    {
    da.Fill(table);
    }
    dataGridView1.DataSource = table;
    }

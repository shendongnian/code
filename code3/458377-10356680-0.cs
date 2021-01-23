    DataTable table = new DataTable("myTable");
    using(OdbcConnection conn = new OdbcConnection("specfiy_conn_string"))
    {
        using(OdbcDataAdapter da = new OdbcDataAdapter(@"SELECT * FROM MyTable", conn))
            da.Fill(table);
    }
    dataGridView1.DataSource = table.DefaultView; //binding table to dgv

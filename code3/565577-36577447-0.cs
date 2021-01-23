    con = new System.Data.SqlServerCe.SqlCeConnection();
    con.ConnectionString = "Data Source=C:\\Users\\mhadj\\Documents\\Visual Studio 2015\\Projects\\data_base_test_2\\Sample.sdf";
    con.Open();
    DataTable dt = new DataTable();
    adapt = new System.Data.SqlServerCe.SqlCeDataAdapter("select * from tbl_Record", con);        
    adapt.Fill(dt);        
    dataGridView1.DataSource = dt;
    con.Close();

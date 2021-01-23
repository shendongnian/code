    string con = "SERVER=localhost; user id=root; password=; database=databasename";
        private void loaddata()
    {
    MySqlConnection connect = new MySqlConnection(con);
    connect.Open();
    try
    {
    MySqlCommand cmd = connect.CreateCommand();
    cmd.CommandText = "SELECT * FROM DATA1";
    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
    DataTable dt = new DataTable();
    da.Fill(dt);
    datagrid.DataSource = dt;
    }
    catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
    }

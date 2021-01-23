    private void getdata()
    {
    MySqlConnection connect = new MySqlConnection("SERVER=localhost; user id=root; password=; database=databasename");
    MySqlCommand cmd = new MySqlCommand("SELECT ID, name FROM data WHERE ID='" + txtid.Text + "'");
    cmd.CommandType = CommandType.Text;
    cmd.Connection = connect;
    connect.Open();
    try
    {
    MySqlDataReader dr;
    dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    txtID.Text = dr.GetString("ID");
    txtname.Text = dr.GetString("name");
    }
    dr.Close();
    }
    catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
    finally
    {
    if(connect.State == ConnectionState.Open)
    {
    connect.Close();
    }
    }

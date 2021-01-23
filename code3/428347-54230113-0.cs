    string con="SERVER=localhost; user id=root; password=; database=dbname";
    public void delete()
    {
    try
    {
    MySqlConnection connect = new MySqlConnection(con);
    MySqlDataAdapter da = new MySqlDataAdapter();
    connect.Open();
    da.DeleteCommand = new MySqlCommand("DELETE FROM table WHERE ID='" + ID.Text + "'", connect);
    da.DeleteCommand.ExecuteNonQuery();
    
    MessageBox.Show("Successfully Deleted");
    }
    catch(Exception e)
    {
    MessageBox.Show(e.Message);
    }
    }

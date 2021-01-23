    public void Query_send(string cmd)
    {
        String config = "server=localhost;uid=root;database=bdcliente;";
        MySqlConnection conn = new MySqlConnection(config);
        MySqlCommand comm = new MySqlCommand(cmd, conn);
        try
        {
            conn.Open();
	        comm.ExecuteNonQuery(); '--this was missing
        }
        catch
        {
            MessageBox.Show("Error when connecting to the database!");
        }
        finally
        {
            conn.Close();
        }
    }

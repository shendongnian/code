    public void CreateMySqlCommand(string myExecuteQuery, MySqlConnection myConnection) 
    {
      MySqlCommand myCommand = new MySqlCommand(myExecuteQuery, myConnection);
      myCommand.Connection.Open();
      myCommand.ExecuteNonQuery();
      myConnection.Close();
    }

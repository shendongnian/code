    public void CreateMySqlCommand() 
    {
      MySqlConnection myConnection = new MySqlConnection("Persist Security Info=False;database=test;server=myServer");
      myConnection.Open();
      MySqlTransaction myTrans = myConnection.BeginTransaction();
      string mySelectQuery = "SELECT * FROM myTable";
      MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection,myTrans);
      myCommand.CommandTimeout = 20;
    }

    try{
      sqlConn.Open();
      OleDbCommand command = new OleDbCommand("CREATE....", sqlConn);
      command.CommandType = CommandType.Text;
      command.ExecuteNonQuery();
    }
    catch(InvalidOperationException ioe)
    {
        ....
    }
    catch(OleDbException ode)
    {
        ....
    }
    sqlConn.Close();

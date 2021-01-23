    public bool VerifyUser(string username, string password)
    {
        bool returnValue = false;
        string Query = "SELECT 1 FROM Base_Character WHERE User='" + username + "' AND pass='"+password+"'";
        try
        {
            MySqlCommand command = new MySqlCommand(Query, this.sqlConn);
            MySqlDataReader myReader = command.ExecuteReader();
            if(myReader.Read())
            {
                returnValue = true;
            }
            myReader.Close();
        }
        catch (Exception excp)
        {
            throw (excp);
        }
   
        return returnValue;
     }

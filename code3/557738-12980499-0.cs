    string selectString =
                    "SELECT username, password " +
                    "FROM users " +
                    "WHERE username = '" + user + "' AND password = '" + password + "'";
    
                    MySqlCommand mySqlCommand = new MySqlCommand(selectString, Program.mySqlConnection);
                    Program.mySqlConnection.Open();
                    String strResult = String.Empty;
                                        
                    if (mySqlCommand.ExecuteScalar()== NULL)
                    {
                        responseString = "invalid";
                        InvalidLogin = true;
                    } else {
                        InvalidLogin = false;
                    }
                   Program.mySqlConnection.Close();

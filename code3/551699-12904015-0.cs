    public string getPassword(string username)
            {
                string returnValue = "";
                string Query = "SELECT Pass FROM Base_Character where (User=" +
                    "'" + username + "') LIMIT 1";
                MySqlCommand checkUser = new MySqlCommand(Query, this.sqlConn);
                try
                {
                    checkUser.ExecuteNonQuery();
                    MySqlDataReader myReader = checkUser.ExecuteReader();
                    while (myReader.Read() != false)
                    {
                        returnValue = myReader.GetString(0);
                    }
                    myReader.Close();
                }
                catch (Exception excp)
                {
                    Exception myExcp = new Exception("Could not grab password: " +
                        excp.Message, excp);
                    throw (myExcp);
                }
                return (returnValue);
            }

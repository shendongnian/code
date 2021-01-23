            dataBaseObj.sqlconn.Open();
            dataBaseObj.sqlCmd = new SqlCommand("SELECT  clEmail, clPassword FROM Client where clEmail='" + username + "'", dataBaseObj.sqlconn);
            dataBaseObj.sqlDr = dataBaseObj.sqlCmd.ExecuteReader();
            if (dataBaseObj.sqlDr.Read())
            {
                if (dataBaseObj.sqlDr["clPassword"].Equals(password.ToString()))
                {
                    strmessage = "client";
                    dataBaseObj.sqlconn.Close();
                }
                else
                {
                    intResult++;
                    strmessage = "login  not succesfull";
                    dataBaseObj.sqlconn.Close();
                    if (intResult == 3)
                    {
                        strmessage = "your Blocked";
                    }
                }
            }    // if its not the client is gonna go to workers table 
            else
            {
                dataBaseObj.sqlCmd = new SqlCommand("SELECT wuUsername, wuPassword, wuUserType FROM  WorkUsers where wuUsername'" + username + "'", dataBaseObj.sqlconn);
                dataBaseObj.sqlDr = dataBaseObj.sqlCmd.ExecuteReader();
                if (dataBaseObj.sqlDr.Read())
                {
                    if (dataBaseObj.sqlDr["wuPassword"].Equals(password.ToString()))
                    {
                        strmessage = "Receptionist";
                        dataBaseObj.sqlconn.Close();
                    }
                    else
                    {
                        intResult++;
                         
                        strmessage = "login  not succesful";
                        dataBaseObj.sqlconn.Close();
                        if (intResult == 3)
                        {
                            strmessage = "your Blocked";
                        }
                    }
                }
            }
            return strmessage;
        }

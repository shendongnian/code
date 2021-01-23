    [WebMethod]
    public bool CheckLogin(string username, string password)
            {
                bool status = false;
    
                SqlCommand Command = new SqlCommand();
                try
                {
                   Command.CommandText="Select count(*) from CM_Users where username='"+username+"' and passwd='"+password+"'";
                   Command.Connection=DbConnection.OpenDbConnection();
                      // this is Assembly Loaded from Application
                   
                   int count=(int)Command.ExecuteScalar();
    
                    if(count>0)
                        status=true;
                    else
                        status=false;
    
                    DbConnection.CloseDbConnection(Command.Connection);
    
                }
                catch (SqlException expmsg)
                {
                    DbConnection.CloseDbConnection(Command.Connection);
    
                }
    
    
                return status;
    
            }

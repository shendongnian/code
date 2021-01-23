    if(Session["email"] != null)
        {
    string password =  txtPassword.Text;
    string email = Session["email"].Tostring();
    
    
        String SQLQuery = "DELETE FROM SignUp Where Password=@pass AND EmailAddress=@email";
    SqlCommand dbComm = new SqlCommand(SQLQuery , new SqlConnection() );
    dbComm.Parameters.Add("@pass", SqlDbType.NVarChar).Value = password ;
    dbComm.Parameters.Add("@pass", SqlDbType.NVarChar).Value = email  ;
    
    //execute sql
        }
        else
        {
           //session timeout
        }

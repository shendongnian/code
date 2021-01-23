    Here is what I tried and it is working fine
    
    **Stored Procedures**
    
    STORED PROCEDURE 1
    
    create procedure spLoginCount
    @userid nvarchar(50),
    @password nvarchar(50),
    @count int out
    as 
    Begin 
    	select @count=count(userid) from users where userid=@userid and pswd=@password
    End
    
    
    
    **STORED PROCEDURE 2**
    
    create procedure spLoginData
    @userid nvarchar(50),
    @usertype nvarchar(20) out,
    @lastlogin nvarchar(100) out
    as 
    Begin 
    	select @usertype=usertype,@lastlogin=lastlogin from users where userid=@userid
    End
    
    
    **ASP.NET code which will get values of two output Parameters**....
    
    
    
     protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uid="", psw="";
            uid = txtUserName.Text;
            psw = txtPassword.Text;
    
             string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
             using (SqlConnection scon = new SqlConnection(cs))
             {
                 SqlCommand scmd = new SqlCommand("spLoginCount", scon);
                 scmd.CommandType = System.Data.CommandType.StoredProcedure;
                 scmd.Parameters.AddWithValue("@userid",uid);
                 scmd.Parameters.AddWithValue("@password", psw);
    
                 SqlParameter outparameter = new SqlParameter();
                 outparameter.ParameterName = "@count";
                 outparameter.SqlDbType = System.Data.SqlDbType.Int;
                 outparameter.Direction = System.Data.ParameterDirection.Output;
                 scmd.Parameters.Add(outparameter);
    
                 scon.Open();
                 scmd.ExecuteScalar();
    
                 string count = outparameter.Value.ToString();
                 if (count == "1")
                 {
                     SqlCommand scmd1= new SqlCommand("spLoginData", scon);
                     scmd1.CommandType = System.Data.CommandType.StoredProcedure;
                     scmd1.Parameters.AddWithValue("@userid", uid);
                     
                     /*SqlParameter outUserType = new SqlParameter();
                     outUserType.ParameterName = "@usertype";
                     outUserType.SqlDbType = System.Data.SqlDbType.NText;
                     outUserType.Direction = System.Data.ParameterDirection.Output;
                     scmd1.Parameters.Add(outUserType);
                     */
                     SqlParameter outUserType = new SqlParameter("@usertype", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                     scmd1.Parameters.Add(outUserType);
    
                     SqlParameter outLastLogin = new SqlParameter("@lastlogin", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                     scmd1.Parameters.Add(outLastLogin);
    
                     scmd1.ExecuteNonQuery();
                     scon.Close();
    
                     string usertype,lastlogin;
                     usertype = outUserType.Value.ToString();
                     lastlogin = outLastLogin.Value.ToString();
                   }
              
                 }
             }

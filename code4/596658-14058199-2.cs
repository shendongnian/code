     public void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            CreateUserProfile(RegisterUser.UserName, RegisterUser.Password);
        
           
        }
       private void CreateUserProfile(string username, string password)
       {
           string connect = System.Configuration.ConfigurationManager.ConnectionStrings["_connection"].ToString();
           SqlConnection con = new SqlConnection(connect);
           string insertcommand="Insert into Users"
               +"(Userid,Password)"
               +"Values(@Userid,@Password)";
           SqlCommand cmd = new SqlCommand(insertcommand, con);
           cmd.Parameters.AddWithValue("@Userid", username);
           cmd.Parameters.AddWithValue("@Password", password);
           using (con)
           {
               con.Open();
               cmd.ExecuteNonQuery();
           }
               
              
       }
    }

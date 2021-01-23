         string sUserName = txtBoxUsername.Text;
        SqlConnection conn2 = new SqlConnection("Your SQL Connection");
        
            SqlCommand myCommand = new SqlCommand("SELECT Email FROM aspnet_Membership WHERE UserName = '"+ sUserName  + "'", conn2);
           
            SqlDataReader rdr = myCommand.ExecuteReader();
         if (dr.HasRows)
        {
              while (rdr.Read())
            {
                     // User exist - get email
    
                     string email = rdr["Email "].toString();
                   
             }
        }
        else
        {
              //Error! user not exist
        }
       

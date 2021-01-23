     readonly SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["VerbaLinksConString"].ToString());
     try
     {
        SqlCommand cmd  = new SqlCommand("Select txt_Password from table where txt_user_name = '"+txtUserName.Text+"' and txt_Pwd = '"+txtPassword.Text+"'",sqlCon);
       sqlCon.Open();
       SqlDataReader dr = cmd.ExecuteReader();
       If(dr.Read())
       {
         Response.Redirect("HomePage.aspx");
       }
       else
       {
         Response.Write("Either userId or Password is wrong");
       }
       SqlCon.Close(); 
    }
    Catch(SqlException ex)
     {
     }
 

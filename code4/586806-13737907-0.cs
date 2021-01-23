    using(SqlConnection connew = new SqlConnection(connectionString))
     {
      strnew = @"select User_Type from User_Details where User_Type=@usertype 
                 AND LoginID=@loginid AND Password = @password";
      using(SqlCommand sqlCommnew = new SqlCommand(strnew, connew))
       {
         sqlCommnew.Parameters.AddWithValue("@usertype",ddlUserSel.SelectedItem.Value);
         sqlCommnew.Parameters.AddWithValue("@loginid",txtUserName.Text);
         sqlCommnew.Parameters.AddWithValue("@password",txtPassword.Text);
    
         connew.Open();
         sdrDatanew = sqlCommnew.ExecuteReader();
         
         int userType=-1;
         if(sdrDatanew.Read())
            userType=sdrDatanew.GetInt32(0);
        
         switch (userType)
          {
           case 0:
               Response.Redirect("Lic_Gen.aspx");
               break;
           case 1:
               Response.Redirect("Cust_Page.aspx");
               break;
          }
        }
    }

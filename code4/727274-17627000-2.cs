    while (dr.Read())
    {
          password = dr["Password"].ToString();
          type = dr["Type"].ToString();
          if ((password == txtPassword.Text.ToString()) && (type == "admin"))
          {
             Response.Redirect("administrator.aspx");
          }
          else if ((password==txtPassword.Text.ToString()) && (type=="general"))
          {
             Response.Redirect("userspage.aspx");
          }
    }
    
    lblMessage.Text = "wrong userid or password";

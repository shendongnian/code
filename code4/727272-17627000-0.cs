      if ((password == txtPassword.Text.ToString()) && (type == "admin"))
      {
         Response.Redirect("administrator.aspx");
      }
      else if ((password==txtPassword.Text.ToString()) && (type=="general"))
      {
         Response.Redirect("userspage.aspx");
      }
      else
      {
         lblMessage.Text = "wrong userid or password";
      }

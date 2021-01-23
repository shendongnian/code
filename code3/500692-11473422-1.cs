    public void OnLoginClick(object sender, EventArgs e)
    {
       if(MySqlValidUser(username, pass)) // this is where you would check if user is valid
       {
          FormsAuthentication.SetAuthCookie(username, null);
          Response.Redirect("/");
       }
    }

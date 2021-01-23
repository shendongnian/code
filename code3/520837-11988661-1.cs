     protected override void OnPreInit(EventArgs e)
        {
            if (session.logged_in == false)
            {
              Response.Redirect("login.aspx", false);            
            }
        }

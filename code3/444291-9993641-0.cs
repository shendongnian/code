    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
             if (Session["loginError"].ToString() == "lockout")
             {
                   LiteralControl errorControl = 
                      new LiteralControl(String.Format("Your account has been locked out. Please wait {0} minutes and try again.", Session.Timeout));
                   ErrorPanel.Controls.Add(errorControl);
                   ErrorPanel.Visible = true;
             }
             // add more login logic for login error
        }
        catch(Exception) //you may want to capture more specific Exceptions
        {
             //handle the exception(s)
        }
    }

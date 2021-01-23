    protected void Session_Start(Object sender, EventArgs e)
    {
         //The first Session "Logged" which is an indicator to the
         //status of the user
         Session["Logged"]="No";
         //The second Session "User" stores the name of the current user
         Session["User"]="";
    
         //The third Session "URL" stores the URL of the
         //requested WebForm before Logging In
         Session["URL"]="Default.aspx";
    }

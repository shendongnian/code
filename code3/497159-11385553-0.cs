    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        System.Web.UI.WebControls.Login Login1 = (System.Web.UI.WebControls.Login)LoginView1.FindControl("Login1");
        TextBox UserName = (TextBox)Login1.FindControl("UserName");
    
        Response.Cookies.Add(new HttpCookie("UserName", Login1.UserName));
        
        // IMPORTANT: Notice that LoginView1 is changed to Login1
        CheckBox RememberMe =  Login1.FindControl("RememberMe") as CheckBox; 
    
        HttpCookie myCookie = new HttpCookie("myCookie");
        if (RememberMe.Checked == true)
        {
            myCookie.Values.Add("username", Login1.UserName);
            myCookie.Expires = DateTime.Now.AddDays(15);
            Response.Cookies.Add(myCookie);
        }
    
    }

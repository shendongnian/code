     protected void Page_Load(object sender, EventArgs e)
        {
         TextBox Password = (TextBox)Login1.FindControl("Password");
         Button ButtonLogin = (Button)Login1.FindControl("LoginButton");
         Password.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13) __doPostBack('" + ButtonLogin.UniqueID + "','')");
        }

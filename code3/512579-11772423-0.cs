     protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Request.IsAuthenticated && User.Identity is FormsIdentity)
            {
                SqlConnection myConnection = new SqlConnection(DBConnection.GetConnectionString());
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Users WHERE login=@login", myConnection);
                myCommand.Parameters.AddWithValue("login", app.Context.User.Identity.Name);
                myCommand.Connection.Open();
                SqlDataReader Reader = myCommand.ExecuteReader();
                var userLogin = string.Empty;
                string role = string.Empty;                
                while (Reader.Read())
                {
                    userLogin = Reader["login"].ToString();
                    role = Reader["role"].ToString();
                }
                if (role != string.Empty)
                {
                    FormsIdentity fi = (FormsIdentity)app.User.Identity;
                    app.Context.User = new GenericPrincipal(fi, new string[] { role });
                    Session["UserLogin"] = userLogin;
                }
            }
        }
    void Session_End(object sender, EventArgs e)
        {            
            if(Session["UserLogin"]!=null)
            {
                var userLogin = (string)Session["UserLogin"];
                DBUsers.SetUserStatusOnline("0", userLogin); 
            }              
        }

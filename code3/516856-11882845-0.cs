    protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                dtUserDetails = new DataTable();
                if (UserRepositoryBL.ValidateUser(LoginUser.UserName.Trim(), LoginUser.Password.Trim(), out dtUserDetails))
                {
    
                    AuthUser au = new AuthUser();
                    if (dtUserDetails.Rows.Count > 0)
                    {
                        DataRow DR = dtUserDetails.Rows[0];
                        au.UserID = Convert.ToInt32(DR["UserID"].ToString());
                        au.UserNo = DR["UserNo"].ToString();
                        au.UserName = DR["UserName"].ToString();
                        au.Password = DR["Password"].ToString();
                    }
                    string userData = au.ToString();
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
    
                 1,                             // Version number
    
                 LoginUser.UserName.Trim(),      // Username
    
                 DateTime.Now,                  // Issue date
    
                 DateTime.Now.AddMinutes(60), // Expiration date
    
                 false,                         // Persistent?
    
                 userData                 // User data
    
             );
    
    
    
                    string eticket = FormsAuthentication.Encrypt(ticket);
    
                    HttpCookie cookie = new HttpCookie
    
                         (FormsAuthentication.FormsCookieName, eticket);
    
                    Response.Cookies.Add(cookie);
    
    
                    BasePage.ActivityLog("User Login", LoginUser.UserName.Trim(), true, Request.RawUrl);
                    string url = FormsAuthentication.GetRedirectUrl(LoginUser.UserName, false);
                   
                    Response.Redirect(url);
    
                    //  FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                   
                }
                else
                {
                    LoginUser.FailureText = "Your login attempt was not successful. Please try again.";
                }
    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

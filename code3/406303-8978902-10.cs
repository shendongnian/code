                    System.Web.Security.FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddDays(1), false, String.Format("{0}|{1}|{2}", user.UserID ,user.Roles.ToString(), user.FirstName ), System.Web.Security.FormsAuthentication.FormsCookiePath);
                    HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, System.Web.Security.FormsAuthentication.Encrypt(ticket));
                    if (model.RememberMe)
                         cookie.Expires = ticket.Expiration;
                    
                    Response.Cookies.Add(cookie);

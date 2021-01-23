    private void CreateAuthentificationTicet(UserModel user)
            {
                var serializedUser = JsonConvert.SerializeObject(user);
    
                var ticket = new FormsAuthenticationTicket(1,               // version 
                                                        user.Email,  // user name
                                                        DateTime.Now,    // create time
                                                        DateTime.Now.AddMinutes(30), // expire time
                                                        false,           // persistent
                                                        serializedUser);             // user data
    
                var strEncryptedTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strEncryptedTicket);
                Response.Cookies.Add(cookie);
            }

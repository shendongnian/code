                // Encrypt the ticket.
                string encryTicket = FormsAuthentication.Encrypt(ticket);
                // Create the cookie.
                HttpCookie userCookie = new HttpCookie("Authentication", encryTicket);
                userCookie.HttpOnly = true;
                Response.Cookies.Add(userCookie);
                e.Authenticated = true;
                if (LoginPannelMain.RememberMeSet)
                {
                    HttpCookie aCookie = new HttpCookie("email", strUserLogin);
                    aCookie.HttpOnly = true;
                    aCookie.Expires = DateTime.Now.AddYears(1);
                    Response.AppendCookie(aCookie);
                }
                else
                {
                    HttpCookie aCookie = new HttpCookie("email", "");
                    aCookie.HttpOnly = true;
                    Response.AppendCookie(aCookie);
                }

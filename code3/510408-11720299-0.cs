                    HttpRequest currentRequest = HttpContext.Current.Request;
                // Attempt to get the Forms Auth Cookie from the Request
                HttpCookie authenticationCookie = currentRequest.Cookies[FormsAuthentication.FormsCookieName];
                if(authenticationCookie != null)
                {
                    // Crack the Cookie open
                    var formsAuthenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                    // breakpoint here to see the contents of the ticket.
                    if (formsAuthenticationTicket.Expired)
                    {
                        
                    }
                }

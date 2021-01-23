        public static ConnectedUser GetConnectedUser(HttpContextBase executingContext)
        {
                var dictionary = GetAuthCookieData(executingContext);
                var toRet = new ConnectedUser
                {
                    FirstName = dictionary["FirstName"],
                    LastName= dictionary["LastName"]
                }
                return toRet;
         }
         public static IDictionary<string, string> GetAuthCookieData(HttpContextBase executingContext)
        {
            HttpCookie toCheck = executingContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket decrypted = FormsAuthentication.Decrypt(toCheck.Value);
            string userData = decrypted.UserData;
            return userData.ToDictionary<string, string>();
        }

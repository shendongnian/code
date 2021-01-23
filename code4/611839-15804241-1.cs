                string cookie = "";
            LoginResult loginResult;
            string result;
            
            AuthenticationSoapClient authentication = new AuthenticationSoapClient();
            UserGroupSoapClient ug = new UserGroupSoapClient();
            using(OperationContextScope scope = new OperationContextScope(authentication.InnerChannel))
            {
                loginResult = authentication.Login("user", "pass");
                if (loginResult.ErrorCode == LoginErrorCode.NoError)
                {
                    MessageProperties props = OperationContext.Current.IncomingMessageProperties;
                    HttpResponseMessageProperty prop = props[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
                    string cookies = prop.Headers["Set-Cookie"];
                    // You must search cookies to find cookie named loginResult.CookieName and set its value to cookie variable;
					cookie = cookies.Split(';').ToList().Where(c => c.StartsWith(loginResult.CookieName)).FirstOrDefault();
                }
            }
            HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
            httpRequestProperty.Headers.Add(System.Net.HttpRequestHeader.Cookie, cookie);
            using (new OperationContextScope(ug.InnerChannel))
            {
                OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, httpRequestProperty);
                result = ug.GetGroupCollectionFromUser(LoginName).ToString();
            }

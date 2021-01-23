     public string CreateLoginjson(string strErrorType, bool blIsAuthenticated)
            {
    
                StringBuilder sbLoginJson = new StringBuilder();
                if (blIsAuthenticated)
                {
                    sbLoginJson.Append("{LoginSuccess:1");
                }
                else
                {
                    sbLoginJson.Append("{LoginSuccess:0");
                }
    
                if (strErrorType != string.Empty)
                {
                    if (strErrorType.TrimEnd(new char[] { ',' }) == "Token" || strErrorType.TrimEnd(new char[] { ',' }).Split(new char[] { ',' }).Contains("BlankToken"))
                    {
                        sbLoginJson.Append(",txtTestTokenNumber1:\"Error\"");
                        sbLoginJson.Append(",txtTestTokenNumber2:\"Error\"");
                        sbLoginJson.Append(",txtTestTokenNumber3:\"Error\"");
                        sbLoginJson.Append(",txtTestTokenNumber4:\"Error\"");
    
                    }
    
    
                    if (strErrorType.TrimEnd(new char[] { ',' }) == "Password" ||  strErrorType.TrimEnd(new char[] { ',' }).Split(new char[] { ',' }).Contains("BlankPassword"))
                    {
                        sbLoginJson.Append(",txtPassword:\"Error\"");
    
                    }
    
                    if (strErrorType.TrimEnd(new char[] { ',' }) == "UserName" ||  strErrorType.TrimEnd(new char[] { ',' }).Split(new char[] { ',' }).Contains("BlankUserName"))
                    {
                            sbLoginJson.Append(",txtUserName:\"Error\"");
                    }
    
                        string strLoadErrorControlMessage = LoadErrorControl(strErrorType, string.Empty);
    
                        if (strLoadErrorControlMessage != string.Empty)
                        {
                            PageTestApplicationLogin objPageTestApplicationLogin = new PageTestApplicationLogin(objClientConfiguration);
                            sbLoginJson.Append(",ErrorMessage:'" + objPageTestApplicationLogin.GetTestApplicationLoginErrorHtml("", strLoadErrorControlMessage).Replace("'", "\"") + "'");
    
                        }
    
                    sbLoginJson.Append("}");
                }
                var LoginJson = sbLoginJson.ToString();
                return LoginJson;
      
            }

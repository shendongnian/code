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
                   //All your error code here
    
                }
    
    
                var LoginJson = sbLoginJson.ToString();
                return LoginJson;
            }

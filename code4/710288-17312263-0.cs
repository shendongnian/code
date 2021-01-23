    public static void SetBasicAuthHeader(WebRequest req, String appID, String userPassword)
        {
            string authInfo = appID + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            req.Headers["Authorization"] = "Basic " + authInfo;
        }

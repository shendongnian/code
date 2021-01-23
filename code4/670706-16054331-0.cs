    private string GetSecureQsToken(string querystring)
    {
        Byte[] buffer = Encoding.UTF8.GetBytes(querystring);
        SHA1CryptoServiceProvider cryptoTransformSha1 =
        new SHA1CryptoServiceProvider();
        string hash = BitConverter.ToString(
            cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");
        return hash;
    }
    private void GoToSecureQsPage()
    {
        string qsvalues = "id=1&page=4";
        Response.Redirect(string.Format("Default.aspx?{0}&hash={1}", qsvalues, GetSecureQsToken(qsvalues)));
    }
    private void ReadSecureQs()
    {
        //here check the normal querystring parameters again against the hash parameter
        if (GetSecureQsToken("id=1&page=4") != Request.QueryString["hash"])
        {
            throw new Exception("Error here");
        }
    }

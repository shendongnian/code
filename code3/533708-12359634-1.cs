    public byte[] GetConnect(string uid, string password)
    {
        ...
        if (iduri != "")
        {
            return SerializeObject(con);
        }
    }
-
    void svc_Get_Connected(object send, GetConnectCompletedEventArgs e)
    {
        CookieContainer con = DeserializeObject<CookieContainer >(e.Result);
    }

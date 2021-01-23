    [WebMethod]
    public DateTime GetCurrentServerTime()
    {
         return System.DateTime.UtcNow.ToString("yyyyMMddZHHmmss");
    }

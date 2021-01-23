    public void ProcessRequest(HttpContext context)
    {
        try
        {
           HttpPostedFile file = context.Request.Files["Filedata"];
           string sessionId = context.Request["sessionId"].ToString();
          ....

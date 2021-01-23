    public void ProcessRequest(HttpContext context)
            {
                if (context.Request.QueryString.GetValues("AppID") != null)
                {
                    appid = context.Request.QueryString.GetValues("AppID")[0].ToString();
                }
    
                if (context.Request.QueryString.GetValues("Ref") != null)
                {
                    refno = context.Request.QueryString.GetValues("Ref")[0].ToString();
                }
    
                if (context.Request.QueryString.GetValues("nurl") != null)
                {
    
                    nurl = HttpUtility.UrlDecode(context.Request.QueryString.GetValues("nurl")[0].ToString());
                }

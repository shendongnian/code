    if(Request.QueryString['callback']!=null){
        string callback = Request.QueryString['callback'];
        string json = "{\"name\":\"Joe\"}";
        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/json";
        Response.ContentEncoding = Encoding.UTF8;
        Response.Write(callback + "(" + json + ")");
        Response.End();
    }

    public static string Entity()
    {
        string entity = "";
        HttpContext httpContext = HttpContext.Current;
        if (httpContext.ApplicationInstance.Session.Count > 0)
            entity = httpContext.ApplicationInstance.Session["EntityCode"].ToString();
    
        return entity;
    }

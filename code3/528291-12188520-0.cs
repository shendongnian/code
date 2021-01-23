    public static string Call()
    {
        string ref1 = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
        HttpContext.Current.Request.Response.Write(ref1);
    }

    public static bool IsLocal
    {
        // MVC < 6
        get { return HttpContext.Request.Url.Authority.Contains("localhost"); }
        // MVC 6
        get { return HttpContext.Request.Host.Contains("localhost"); }
    }

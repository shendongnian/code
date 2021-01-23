    internal static HttpContextBase Context
    {
        get
        {
            return new HttpContextWrapper(HttpContext.Current);
        }
    }

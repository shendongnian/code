    public static bool IsAdmin
    {
        get { return (HttpContext.Current.Items["IsAdmin"] as bool?) ?? false; }
        set { HttpContext.Current.Items["IsAdmin"] = value; }
    }

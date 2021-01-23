    public static string TestSessionValue 
    { 
        get 
        {
            object value = HttpContext.Current.Session["TestSessionValue"];
            return value == null ? "" : (string)value;
        }
        set 
        {
            HttpContext.Current.Session["TestSessionValue"] = value;
        }
    }

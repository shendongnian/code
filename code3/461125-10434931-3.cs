    public static String AccessLevel {
        get
        {
            return Convert.ToString(HttpContext.Current.Session["AccessLevel"]);
        }
        set
        {
            HttpContext.Current.Session["AccessLevel"] = value;
        }
    }

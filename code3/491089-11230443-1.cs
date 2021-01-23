    public static Datatype data
    {
        get
        {
            return (Datatype)HttpContext.Current.Items["DATA"];
        }
        set
        {
            HttpContext.Current.Items["DATA"] = value;
        }
    }

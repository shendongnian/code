    public static DUOSDatatype grant
    {
        get
        {
            return (DUOSDatatype)HttpContext.Current.Items["DUOSDATA"];
        }
        set
        {
            HttpContext.Current.Items["DUOSDATA"] = value;
        }
    }

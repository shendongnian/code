    // bad - any caller can access this in any sequence
    public static int CurrentUserId
    {
        get;
        set;
    }
    
    // okay, because the backing storage is safe/segmented
    public static int CurrentUserId
    {
        get { return (int)Session["CurrentUserId"]; }
        set { Session["CurrentUserId"] = value; }
    }
    // data that you want to be shared
    public static List<string> SomeValuesToBeShared
    {
        // safe for reading (if properly initialized) 
        // safe for writing only if appropriate locks are used
    }

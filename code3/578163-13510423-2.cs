    public static string ToSpecialString(this StaticUser source)
    {
        const string dBString = "Database"
        
        switch (source)
        {
            case StaticUser.DB:
                return dBString;
 
            default:
                return source.ToString();
        }
    }

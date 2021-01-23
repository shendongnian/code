    enum Provider
    {
        None = 0,
        OpenID = 0x1,
        OAuth =  0x2,
        Google =   0x10 | OpenID,
        Aol =      0x20 | OpenID,
        Facebook = 0x30 | OAuth,
        Twitter =  0x40 | OAuth | OpenID // can set both flags!
    }
    static bool IsOpenID(Provider p)
    {
        return (p & Provider.OpenID) == Provider.OpenID;
    }
    static bool IsOAuth(Provider p)
    {
        return (p & Provider.OAuth) == Provider.OAuth;
    }

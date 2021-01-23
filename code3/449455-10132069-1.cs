    public static bool IsConnectedToInternet( )
    {
        try
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        catch 
        {
            return false;
        }
    }

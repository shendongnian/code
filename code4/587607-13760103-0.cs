    public static bool ActiveSyncConnected
    {
        get
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry("PPP_PEER");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }        

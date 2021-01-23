    public static ActiveClient GetClient(string clientID)
    {
        // Cannot continue without a ClientStatus
        if(ClientStatus == null) 
        {
            return null;
        }
        
        ActiveClient activeClient = null;
        try
        {
            lock (ClientStatus)
            {
                // Test if there are any matching elements
                if(ClientStatus.Any(c => c.clinetID == clientID))
                {
                    activeClient = ClientStatus.Find(c => c.clinetID != null && c.clinetID == clientID);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
        // This will return null if there are no matching elements
        return activeClient;
    }

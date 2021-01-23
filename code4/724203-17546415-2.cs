    public static void SetClinetStatus(string ClientID, int clinetstatus)
    {
        ClientID = ClientID.Trim();
        // Cannot run unless there is a ClientID submitted
        if(string.IsNullOrEmpty(ClientID))
        {
            // Log handling of event
            return;
        }
    
        ActiveClient activeClient=null;
        try
        {
            activeClient = GetClient(ClientID);
            if (activeClient != null)
            {
                activeClient.statuschanged = true;
                activeClient.status = clinetstatus;
            }
        }
        catch (Exception ex)
        {
            WebserviceLog.Debug(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + "::" + System.Reflection.MethodBase.GetCurrentMethod().ToString() + ":" + ex.Message);
        }
    
    }

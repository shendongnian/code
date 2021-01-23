    using Microsoft.Web.Administration;
    
    public bool RecycleApplicationPool(string appPoolName)
    {
    
        try
        {
            using (ServerManager iisManager = new ServerManager())
            {
                 iisManager.ApplicationPools[appPoolName].Recycle();
                 return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unhandled Exception");
        }
    }

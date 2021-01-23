    using Microsoft.Web.Administration;
    
    public bool RecycleApplicationPool(string appPoolName)
    {
    
        try
        {
            using (ServerManager iisManager = new ServerManager())
            {
                 iisManager.APplicationPools[appPoolName].Recycle;
                 return true;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unhandled Exception");
        }
    }

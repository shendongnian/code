    //Add this to your using statements:
    using Microsoft.Web.Administration;
    
    //You can get the App Pool identity like this:    
    public string GetAppPoolIdentity(string appPoolName)
    {
    	var serverManager = new ServerManager();
    
    	ApplicationPool appPool = serverManager.ApplicationPools[appPoolName];
        appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
        return appPool.ProcessModel.UserName;            
    }

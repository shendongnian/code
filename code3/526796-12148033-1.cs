    ServerManager serverManager = new ServerManager();
    Site site = serverManager.Sites[0]; // get site by Index or by siteName
    ApplicationPool appPool = serverManager.ApplicationPools[1]; // get appPool by Index or by appPoolName
    site.Stop();
    site.ApplicationDefaults.ApplicationPoolName = appPool.Name;
    foreach (var item in site.Applications)
    {
        item.ApplicationPoolName = appPool.Name;
    }
    serverManager.CommitChanges();  // this one is crucial!!! see MSDN: 
    // Updates made to configuration objects must be explicitly written to the configuration 
    // system by using the CommitChanges method!!
    site.Start();
    appPool.Recycle();

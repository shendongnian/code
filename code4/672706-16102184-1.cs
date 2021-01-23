    private TfsConfigurationServer configurationServer;  
    
    configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(uri);
  
    public IList<KeyValuePair<string, Uri>> GetBuildDefinitionListFromProject(Guid collectionId, string projectName)
    {
    	List<IBuildDefinition> buildDefinitionList = null;
    	List<KeyValuePair<string, Uri>> buildDefinitionInfoList = null;
    
    	try
    	{
    		buildDefinitionInfoList = new List<KeyValuePair<string, Uri>>();
    		TfsTeamProjectCollection tfsProjectCollection =
    	    configurationServer.GetTeamProjectCollection(collectionId);
    		tfsProjectCollection.Authenticate();
    		var buildServer = (IBuildServer)tfsProjectCollection.GetService(typeof(IBuildServer));
    		buildDefinitionList = new List<IBuildDefinition>(buildServer.QueryBuildDefinitions(projectName));
    	}
    	catch (Exception e)
    	{
    		ApplicationLogger.Log(e);
    	}
    
    	if (buildDefinitionList != null && buildDefinitionList.Count > 0)
    	{
    		foreach (IBuildDefinition builddef in buildDefinitionList)
    		{
    			buildDefinitionInfoList.Add(new KeyValuePair<string, Uri>(builddef.Name, builddef.Uri));
    		}
    	}
    	return buildDefinitionInfoList;
    }

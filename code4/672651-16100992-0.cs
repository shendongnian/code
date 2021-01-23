    private TfsConfigurationServer configurationServer;
    configurationServer = TfsConfigurationServerFactory.GetConfigurationServer(uri);
    public IList<KeyValuePair<Guid, String>> GetCollections()
    {
        //ApplicationLogger.Log("Entered into GetCollections() : ");
        var collectionList = new List<KeyValuePair<Guid, String>>();
        try
        {
            configurationServer.Authenticate();
            ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(
                new[] { CatalogResourceTypes.ProjectCollection },
                false,
                CatalogQueryOptions.None);
            foreach (CatalogNode collectionNode in collectionNodes)
            {
                var collectionId = new Guid(collectionNode.Resource.Properties["InstanceId"]);
                TfsTeamProjectCollection teamProjectCollection =
                    configurationServer.GetTeamProjectCollection(collectionId);
                if (teamProjectCollection == null)
                    continue;
                collectionList.Add(new KeyValuePair<Guid, String>(collectionId, teamProjectCollection.Name));
            }
        }
        catch (Exception e)
        {
            ApplicationLogger.Log(e);
        }
        return collectionList;
    }
  
  

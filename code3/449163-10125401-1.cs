	private static IDocumentStore GetRavenDatabase()
	{
		Shards shards = new Shards();
		ShardedDocumentStore documentStore = null;
		try
		{
			shards.Add(new DocumentStore { Url = ConfigurationManager.AppSettings["RavenShard1"] });
			shards.Add(new DocumentStore { Url = ConfigurationManager.AppSettings["RavenShard2"] });
			documentStore = new ShardedDocumentStore(new ShardStrategy(), shards);
			documentStore.Initialize();
			IndexCreation.CreateIndexes(typeof(RavenDataAccess).Assembly, documentStore);
			return documentStore;
		}
		catch
		{
			if (documentStore != null)
			{
				documentStore.Dispose();
			}
			else
			{
				shards.ForEach(docStore => docStore.Dispose());
			}
			throw;
		}
	}

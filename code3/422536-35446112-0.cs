    public static EntityConnection GetEntityConnection(
    // Build the connection string.
      var sqlBuilder = new SqlConnectionStringBuilder();
      sqlBuilder.DataSource = serverName;
      sqlBuilder.InitialCatalog = databaseName;
      sqlBuilder.MultipleActiveResultSets = true;
      ...
      var providerString = sqlBuilder.ToString();
      var sqlConnection = new SqlConnection(providerString);
    // Build the emtity connection.
      Assembly metadataAssembly = Assembly.GetExecutingAssembly();
      Assembly[] metadataAssemblies = { metadataAssembly };
      var metadataBase = @"res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl";
      var dbModelMetadata = String.Format(metadataBase, objectContextTypeModelName);
      // eg: "res://*/Models.MyDatabaseModel.csdl|res://*/Models.MyDatabaseModel.ssdl|res://*/Models.MyDatabaseModel.msl"
      var modelMetadataPaths = modelMetadata.Split('|');
      var metadataWorkspace = new MetadataWorkspace(modelMetadataPaths, metadataAssemblies);
      var entityDbConnection = new EntityConnection(metadataWorkspace, sqlConnection);
      return entityDbConnection;

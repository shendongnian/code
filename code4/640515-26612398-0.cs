    	private void GetSchemaMetaInfo(DbConnection connection)
		{
			var metaDataCollections = connection.GetSchema("MetaDataCollections");
			var dataSourceInformation = connection.GetSchema("DataSourceInformation");
			var dataTypes = connection.GetSchema("DataTypes");
			var restrictions = connection.GetSchema("Restrictions");
			var reservedWords = connection.GetSchema("ReservedWords");
		}

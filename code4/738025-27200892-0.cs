	var metaDataList = new List<IDictionary<String, Object>>();
	using (SqlDataReader reader = cmd.ExecuteReader())
	{
		var hasRows = reader.HasRows;
		while (reader.Read())
		{
			for (int i = 0; i < reader.FieldCount; i++)
			{
				dynamic fieldMetaData = new ExpandoObject();
				var columnName = reader.GetName(i);
				var value = reader[i];
				var dotNetType = reader.GetFieldType(i);
				var sqlType = reader.GetDataTypeName(i);
				var specificType = reader.GetProviderSpecificFieldType(i);
				fieldMetaData.columnName = columnName;
				fieldMetaData.value = value;
				fieldMetaData.dotNetType = dotNetType;
				fieldMetaData.sqlType = sqlType;
				fieldMetaData.specificType = specificType;
				metaDataList.Add(fieldMetaData);
			}
		}
	}

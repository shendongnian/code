		internal T GetObject<T>(DataTable schemaTable, object[] values, IDictionary<string, string> mappings)
		{
			if (mappings == null || mappings.Count == 0)
			{
				return GetObject<T>(schemaTable, values);
			}
			var finalMappings = GetMappingsFromSchema(schemaTable, mappings);
			return GetObject<T>(values, finalMappings);
		}
                private IDictionary<int, string> GetMappingsFromSchema(DataTable schemaTable)
		{
			if (schemaTable == null || schemaTable.Rows.Count == 0)
			{
				return null;
			}
			var dict = new Dictionary<int, string>();
			for (var i = 0; i < schemaTable.Rows.Count; i++)
			{
				dict.Add(i, schemaTable.Rows[i]["ColumnName"].ToString());
			}
			return dict;
		}

		public IEnumerable<T> SqlQuery<T>(string sql, object[] parameters, IDictionary<string, string> mappings) 
		{
			var list = new List<T>();
			var converter = new DataConverter();
			Open();
			using (var cmd = CreateCommand(sql, parameters))
			{
				var reader = cmd.ExecuteReader();
				if (reader == null)
				{
					return list;
				}
				var schemaTable = reader.GetSchemaTable();
				while (reader.Read())
				{
					var values = new object[reader.FieldCount];
					reader.GetValues(values);
					var item = converter.GetObject<T>(schemaTable, values, mappings);
					list.Add(item);
				}
			}
			return list;		
		}

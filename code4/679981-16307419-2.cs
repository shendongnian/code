    using (var cmd = CreateCommand(sql, parameters))
			{
				var reader = cmd.ExecuteReader();
				if (reader == null)
				{
					return null;
				}
    
				var schemaTable = reader.GetSchemaTable();
                                DataTable dt = GetTable(schemaTable);
				while (reader.Read())
				{
					var values = new object[reader.FieldCount];
					reader.GetValues(values);
                                        dt.Rows.Add(values);
				
				}
			}

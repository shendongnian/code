		private IEnumerable<dynamic> ReaderToAnonymmous(SqlCommand comm) {
			using (var reader = comm.ExecuteReader()) {
				var schemaTable = reader.GetSchemaTable();
				List<string> colnames = new List<string>();
				foreach (DataRow row in schemaTable.Rows) {
					colnames.Add(row["ColumnName"].ToString());
				}
				while (reader.Read()) {
					var data = new ExpandoObject() as IDictionary<string, Object>;
					foreach (string colname in colnames) {
						var val = reader[colname];
						data.Add(colname, Convert.IsDBNull(val) ? null : val);
					}
					yield return (ExpandoObject)data;
				}
			}
		}

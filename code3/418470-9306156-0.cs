			public static class Extensions
			{
				public static Dictionary<TKey, TRow> TableToDictionary<TKey,TRow>(
					this DataTable table,
					Func<DataRow, TKey> getKey,
					Func<DataRow, TRow> getRow)
				{
					return table
						.Rows
						.OfType<DataRow>()
						.ToDictionary(getKey, getRow);
				}
			}
			
			
			
			public static void SampleUsage()
			{
				DataTable t = new DataTable();
				
				var dictionary = t.TableToDictionary(
					row => row.Field<int>("ID"),
					row => new {
						Age = row.Field<int>("Age"),
						Name = row.Field<string>("Name"),
						Address = row.Field<string>("Address"),
					});
			}

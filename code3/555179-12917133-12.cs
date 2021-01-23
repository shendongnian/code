	var destinationTable = new DataTable();
	foreach (var column in newtable.Columns.Cast<DataColumn>())
		destinationTable.Columns.Add(column.ColumnName, typeof(String));
	var result11 =
		from t1 in newtable.AsEnumerable()
		group t1 by new
						{
							Name = t1.Field<String>("Name"),
							LastName = t1.Field<String>("Lastname"),
							Comment = t1.Field<String>("Comment"),
						}
			into grp
			select
				variableColumnNames.ToDictionary(
					columnName => columnName,
					columnName => grp.Max(r => r.Field<String>(columnName)))
				.Concat(new Dictionary<string, string>
						{
							{"Name", grp.Key.Name},
							{"Lastname", grp.Key.LastName},
							{"Comment", grp.Key.Comment}
						}
				).ToDictionary(x => x.Key, x => x.Value);
	foreach (var row in result11)
	{
		var newRow = destinationTable.NewRow();
		foreach (var columnName in newtable.Columns.Cast<DataColumn>().Select(c => c.ColumnName))
			newRow[columnName] = row[columnName];
		destinationTable.Rows.Add(newRow);
	}

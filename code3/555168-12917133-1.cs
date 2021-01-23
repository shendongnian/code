	var variableColumnNames = newtable.Columns.Cast<DataColumn>()
		.Select(c => c.ColumnName)
		.Except(new[]{"Name", "Lastname", "Comment"});
	var result11 = from t1 in newtable.AsEnumerable()
		group t1 by new
		{
			Name = t1.Field<String>("Name"),
			LastName = t1.Field<String>("LastName"),
			Comment = t1.Field<String>("Comment"),
		} into grp
		select new
		{
			grp.Key.Name,
			grp.Key.LastName,
			grp.Key.Comment,
			Values = variableColumnNames.ToDictionary(
				columnName => columnName,
				columnName => grp.Max(r => r.Field<String>(columnName)))
		};

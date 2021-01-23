	var result11 = from t1 in newtable.AsEnumerable()
		group t1 by new
		{
			Name = t1.Field<String>("Name"),
			LastName = t1.Field<String>("LastName"),
			Comment = t1.Field<String>("Comment"),
		} into grp
		select CreateNewDynamicObject
			(
				grp.Key.Name,
				grp.Key.LastName,
				grp.Key.Comment,
				variableColumnNames.ToDictionary(
					columnName => columnName,
					columnName => grp.Max(r => r.Field<String>(columnName)))
			);
		}

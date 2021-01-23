	var query = from x in objects;
	switch (columnIndicator)
	{
		case ColumnIndicatorTypes.Column1:
			query = query.Where(x => x.Column1 == "8");
			break;
		case ColumnIndicatorTypes.Column2:
			query = query.Where(x => x.Column2 == "8");
			break;
		case ColumnIndicatorTypes.Column3:
			query = query.Where(x => x.Column3 == "8");
			break;
		case ColumnIndicatorTypes.Column4:
			query = query.Where(x => x.Column4 == "8");
			break;
	}

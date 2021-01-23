	DbGeometry anyDbGeometry;
	SqlGeometry anySqlGeometry;
	
	//Convert to DbGeometry
	anyDbGeometry = anySqlGeometry.ToDbGeometry();
	
	//Convert to SqlGeometry
	anySqlGeometry = anyDbGeometry.ToSqlGeometry();

    private SharpMap.Styles.VectorStyle GetCountryStyle(SharpMap.Data.FeatureDataRow row)
    {
    	SharpMap.Styles.VectorStyle style = new SharpMap.Styles.VectorStyle();
    	switch (row["NAME"].ToString().ToLower())
    	{
    		case "denmark": //If country name is Danmark, fill it with green
    			style.Fill = Brushes.Green;
    			return style;
    		case "united states": //If country name is USA, fill it with Blue and add a red outline
    			style.Fill = Brushes.Blue;
    			style.Outline = Pens.Red;
    			return style;
    		case "china": //If country name is China, fill it with red
    			style.Fill = Brushes.Red;
    			return style;
    		default:
    			break;
    	}
    	//If country name starts with S make it yellow
    	if (row["NAME"].ToString().StartsWith("S"))
    	{
    		style.Fill = Brushes.Yellow;
    		return style;
    	}
    	// If geometry is a (multi)polygon and the area of the polygon is less than 30, make it cyan
    	else if (row.Geometry is GeoAPI.Geometries.IPolygonal && row.Geometry.Area < 30)
    	{
    		style.Fill = Brushes.Cyan;
    		return style;
    	}
    	else //None of the above -> Use the default style
    		return null;
    }

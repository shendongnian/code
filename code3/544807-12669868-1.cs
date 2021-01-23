    public static IEnumerable<Envelope> GetTiles(string xmlFileName, int level, Rect viewportData, bool debug = false)
    {
    	// viewport data
    	double x = viewportData.X, y = viewportData.Y;
    	double width = viewportData.Width, height = viewportData.Height;
    
    	// load level data
    	XDocument doc = XDocument.Load(xmlFileName);
    	if (doc == null)
    	{
    		throw new FileNotFoundException("File '" + xmlFileName + "' not found.");
    	}
    
    	XElement levelData =
    		doc.Element("levels")
    			.Descendants()
    			.First(element => int.Parse(element.Attribute("nr").Value) == level);
    
    	double minX = double.Parse(levelData.Attribute("minX").Value);
    	double maxX = double.Parse(levelData.Attribute("maxX").Value);
    	double minY = double.Parse(levelData.Attribute("minY").Value);
    	double maxY = double.Parse(levelData.Attribute("maxY").Value);
    
    	int tilesCountX = int.Parse(levelData.Attribute("tilesCountX").Value);
    	int tilesCountY = int.Parse(levelData.Attribute("tilesCountY").Value);
    
    	double scaleFactor = double.Parse(levelData.Attribute("scaleFactor").Value);
    	double rasterXSize = double.Parse(levelData.Attribute("rasterXSize").Value);
    	double rasterYSize = double.Parse(levelData.Attribute("rasterYSize").Value);
    	double lastTileXSize = double.Parse(levelData.Attribute("lastTileXSize").Value);
    	double lastTileYSize = double.Parse(levelData.Attribute("lastTileYSize").Value);
    
    	Envelope[][] extents = new Envelope[tilesCountX][];
    
    	Envelope bounds = new Envelope();
    	bounds.MinX = 0;
    	bounds.MaxX = 0;
    	bounds.MinY = 0;
    	bounds.MaxY = 0;
    
    	double tileGeoWidth = rasterXSize * scaleFactor;
    	double tileGeoHeight = rasterYSize * scaleFactor;
    	for (int i = 0; i < extents.Length; i++)
    	{
    		double offsetY = (double) i*tileGeoHeight;
    		extents[i] = new Envelope[tilesCountY];
    		for (int j = 0; j < extents[i].Length; j++)
    		{
    			// count extents for pieces
    			double offsetX = (double) j*tileGeoWidth;
    			
    			extents[i][j] = new Envelope();
    			extents[i][j].MinX = minX + offsetX;
    			extents[i][j].MinY = minY + offsetY;
    			extents[i][j].MaxX = minX + tileGeoWidth + offsetX;
    			extents[i][j].MaxY = minY + tileGeoHeight + offsetY;
    
    			// last tiles are cut
    			if (j == extents[i].Length - 1)
    			{
    				extents[i][j].MaxX -= (rasterXSize - lastTileXSize);
    				extents[i][j].MinY -= (rasterYSize - lastTileYSize);
    			}
    
    			// check if a piece matches to the viewport
    			// 1. find geo-bounds
    			if (offsetX <= x)
    				bounds.MinX = offsetX;
    			if (offsetX <= x + width)
    				bounds.MaxX = offsetX;
    			if (offsetY <= y)
    				bounds.MinY = offsetY;
    			if (offsetY <= y + height)
    				bounds.MaxY = offsetY;
    		}
    	}
    
    	// 2. increase "max" bounds (+ width/height)
    	bounds.MaxX += width;
    	bounds.MaxY += height;
    
    	var intersectedTiles =
    		extents
    		.SelectMany(es => es)
    		.Where(e => EnvIntersects(e, bounds))
    		.ToList();
    
    	if (debug)
    	{
    		Console.WriteLine("GLOBAL_EXTENT = {0}, {1}, {2}, {3}", minX, maxX, minY, maxY);
    		Console.WriteLine("TILES_COUNT = {0}/{1}", tilesCountX, tilesCountY);
    		for (int i = 0; i < extents.LongLength; i++)
    		{
    			for (int j = 0; j < extents.Length; j++)
    			{
    				Console.WriteLine("EXTENTS = ({0}, {1}, {2}, {3})", extents[i][j].MinX, extents[i][j].MaxX, extents[i][j].MinY, extents[i][j].MaxY);
    			}
    		}
    		foreach (Envelope intersectedTile in intersectedTiles)
    		{
    			Console.WriteLine("INTERSECTION = ({0}, {1}, {2}, {3})", intersectedTile.MinX, intersectedTile.MaxX,
    							  intersectedTile.MinY, intersectedTile.MaxY);
    		}
    	}
    
    	return intersectedTiles;
    }

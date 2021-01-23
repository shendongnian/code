	List<Tile> tiles = new List<Tile>();
	XmlSerializer serializer = XmlSerializer(typeof(Tile));
	using (XmlTextReader xr = new XmlTextReader(xmlStream))
	{
		while (!xr.EOF)
		{
			xr.MoveToContent();
			xr.ReadToDescendant("tile");
			if (xr.Name == "tile")
			{
				string tileXml = xr.ReadOuterXml();
				using (StringReader tileReader = new StringReader(tileXml))
				{
					Tile tile = (Tile)serializer.Deserialize(tileReader);
					tiles.Add(Tile);
				}
			}
			else
			{
				xr.ReadEndElement();
			}
		}
	}

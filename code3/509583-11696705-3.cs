		string xml = @"<images>
        <image href=""http://images1.com/test.jpg"" id=""285"" />
        <image href=""http://images1.com/test2.jpg"" id=""286"" />        
    </images>";
		List<string> images = new List<string>();
		using (StringReader sr = new StringReader(xml))
		using (XmlTextReader xr = new XmlTextReader(sr))
		{
			while (!xr.EOF)
			{
				xr.MoveToContent();
				xr.ReadToDescendant("image");
				xr.MoveToAttribute("href");
				xr.ReadAttributeValue();			
				images.Add(xr.Value);
				xr.MoveToElement();
				if (xr.Name != "images")
				{
					xr.ReadElementString();
				}
				else
				{
					xr.ReadEndElement();
				}
			}
		}

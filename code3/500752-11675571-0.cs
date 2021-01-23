    XDocument xdoc = XDocument.Load(path);
    var elements = xdoc.Elements().Elements();
    XName pageXName = XName.Get("Page","http://schemas.microsoft.com/visio/2003/core");
    var pages = elements.Elements(pageXName);
    
    foreach (XElement page in pages)
    {                
    	XName shapeXName = XName.Get("Shape","http://schemas.microsoft.com/visio/2003/core");
    	var shapes = from shape in page.Elements().Elements(shapeXName)
    				 where shape.Attribute("Type").Value == "Group"
    				 select shape;
    
    	foreach (XElement shape in shapes)
    	{
    		var shapeShapes = shape.Elements();
    		List<XElement> textShapes = shapeShapes.Elements(shapeXName).ToList();
    
    		XName textXName = XName.Get("Text","http://schemas.microsoft.com/visio/2003/core");
    		XName cpXName = XName.Get("Text", "http://schemas.microsoft.com/visio/2003/core");
    
    		string tableName = textShapes[0].Elements(textXName).SingleOrDefault().Value;
    		string columns = textShapes[1].Elements(textXName).SingleOrDefault().Value;
    
    		Debug.WriteLine("-------------" + tableName.TrimEnd('\n') + "---------------");
    		Debug.Write(columns);
    		Debug.WriteLine("----------------------------");
    
    	}
    }

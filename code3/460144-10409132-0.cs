	foreach (var node in doc.Nodes()) 
	{
		if (node.NodeType == XmlNodeType.Text) Console.WriteLine("Text: {0}", node.ToString().Trim());
		else if (node.NodeType == XmlNodeType.Element) 
		{
			var element = (XElement)node;
			Console.WriteLine("Element: Name={0} Type={1} Value={2}",
			                  element.Name, element.Attribute("type").Value, element.Value);
		}
	}

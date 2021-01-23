	var xml = new XDocument();
	var rootElement = new XElement("factors");
	foreach (TreeNode node in tree.Nodes)
	{
		foreach (TreeNode subNode in node.Nodes)
		{
			var attribute = new XAttribute("number", subNode.Text);
			var element = new XElement("factor", attribute);
			foreach (TreeNode subSubNode in subNode.Nodes)
			{
				var subElement = new XElement("code", subSubNode.Text);
				element.Add(subElement);
			}
			rootElement.Add(element);
		}
	}
	xml.Add(rootElement);
	xml.ToString(); // gives you the XML code
	// OR save the XML directly to file
	//xml.Save(@"c:\temp\output.xml");

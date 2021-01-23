	var xmlSource = @"<?xml version=""1.0"" encoding=""utf-8""?>
						<factors>
							<factor number=""1"" price=""1000"">
								<code>12</code>
								<group>A</group>
							</factor>
							<factor number=""2"" price=""10"">
								<code>1</code>
								<group>B</group>
							</factor>
						</factors>";
	var xml = XDocument.Parse(xmlSource);
	var factors = xml.Root.Descendants("factor").ToList();
	// create tree and add root node
	// TreeView tr = new TreeView();
	// var root = tr.Nodes.Add("Factors");
	foreach (var factor in factors)
	{
		var nodeNumber = factor.Attribute("number").Value;
		var subNodeCode = factor.Element("code").Value;
		// add attribute as node name
		// var node = root.Nodes.Add(nodeNumber);
		// add elements as sub nodes
		// node.Nodes.Add(subNodeCode)
	}

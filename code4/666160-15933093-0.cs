	umbraco.NodeFactory.Node node = uQuery.GetNodesByName("Page Name")
		.Where(n => n.NodeTypeAlias == "NodeTypeAlias").FirstOrDefault();
	if (node != null)
	{
		//...
	}

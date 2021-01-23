	umbraco.NodeFactory.Node node = uQuery.GetNodesByType("NodeTypeAlias")
		.Where(n => n.Name == "Page Name").FirstOrDefault();
	if (node != null)
	{
		//...
	}

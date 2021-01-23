    protected void Page_Load(object sender, EventArgs e)
    {
		XmlDocument doc = new XmlDocument();
		doc.Load(@"c:\temp\cars.xml");
		Recurse(doc.ChildNodes);
    }
	private void Recurse(XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
		{
			if (node.InnerText != null)
				node.InnerText = node.InnerText.Trim();
			if (node.Attributes != null)
			{
				foreach (XmlAttribute att in node.Attributes)
					att.Value = att.Value.Trim();
			}
			Recurse(node.ChildNodes);
		}
	}

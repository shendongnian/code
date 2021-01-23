		private XmlNodeList readNodes(String xmlFilePath, String nodeName)
		{
			FileStream reader = new FileStream(xmlFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			System.Xml.XmlDocument source = new System.Xml.XmlDocument();
			source.Load(reader);
			return source.GetElementsByTagName(nodeName);
		}
		public List<Band> readBands(String xmlFilePath)
		{
			List<Band> results = new List<Band>();
			foreach (XmlNode node in readNodes(xmlFilePath, "Band"))
			{
				results.Add(new Band { Members = node.Attributes["members"].Value, Name = node.Attributes["name"].Value });
			}
			results.Sort();
			return results;
		}

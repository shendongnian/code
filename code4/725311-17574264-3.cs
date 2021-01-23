	[Test]
	public void TestXPathExpression()
	{
		var idList = new List<string> { "test_001" };
		var resultsList = new List<string>();
		// Replace with appropriate method to open your URL.
		using (var reader = new XmlTextReader(File.OpenRead("fixtures\\XLIFF_sample_01.xlf")))
		{
			var doc = new XmlDocument();
			doc.Load(reader);
			var root = doc.DocumentElement;
				
			// This is necessary, since your example is namespaced.
			var nsmgr = new XmlNamespaceManager(doc.NameTable);
			nsmgr.AddNamespace("x", "urn:oasis:names:tc:xliff:document:1.2");
			// Go directly to the node from which you want the result to come from.
			foreach (var nodes in idList
				.Select(id => root.SelectNodes("//x:file/x:body/x:id[@idName='" + id + "']/x:result-unit/x:result", nsmgr))
				.Where(nodes => nodes != null && nodes.Count > 0))
					resultsList.AddRange(nodes.Cast<XmlNode>().Select(node => node.InnerText));
				
		}
		// Print the resulting list.
		resultsList.ForEach(Console.WriteLine);
	}

	[TestFixture]
	public class XmlDataTests
	{
	    XmlDocument doc = new XmlDocument();
		[Test]
		public void TestMethod()
		{
			var rootNode = doc.CreateElement("Leads");
			doc.AppendChild(rootNode);
			
			var rowNode = doc.CreateElement("row");
			var attribute = doc.CreateAttribute("no");
			attribute.Value = "1";
			rowNode.Attributes.Append(attribute);
			
			rowNode.AppendChild(GenerateNode("Lead Source","Web Download"));
			rowNode.AppendChild(GenerateNode("First Name","Robert"));
			rowNode.AppendChild(GenerateNode("Last Name","Snyder"));
			rowNode.AppendChild(GenerateNode("Email","rob@snyder.com"));
			rowNode.AppendChild(GenerateNode("Title","Programmer"));
			rowNode.AppendChild(GenerateNode("Phone","1029384756"));
			rowNode.AppendChild(GenerateNode("Home Phone","6574839201"));
			rowNode.AppendChild(GenerateNode("Other Phone","1243567890"));
			rowNode.AppendChild(GenerateNode("Fax","098776545432"));
			rowNode.AppendChild(GenerateNode("Mobile","1243098566"));
			
			rootNode.AppendChild(rowNode);
			doc.Save("C:\\test.xml");
		}
		
		private XmlNode GenerateNode(string field, string innerValue)
		{
		    var xmlNode = doc.CreateElement("FL");
			var xmlAttribute = doc.CreateAttribute("val");
			xmlAttribute.Value = field;
			xmlNode.Attributes.Append(xmlAttribute);
			xmlNode.InnerText = innerValue;
			
			return xmlNode;
		}
	}

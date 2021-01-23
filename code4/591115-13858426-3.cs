    XmlTextReader reader = new XmlTextReader(@"C:\MyXml.xml");
			reader.Read();
			XmlDocument doc = new XmlDocument();
			doc.Load(reader);
			XmlNodeList lstNode = doc.SelectNodes("/Persons/Person[@Manager_Id]");
			foreach (XmlNode node in lstNode)
			{
				node.ParentNode.RemoveChild(node);
			}
			reader.Close();
			doc.Save(@"C:\MyXml.xml"); 

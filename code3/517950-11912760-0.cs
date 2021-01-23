		public void test_xml_split()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("C:\\animals.xml");
			XmlDocument newXmlDoc = null;
			foreach (XmlNode animalNode in doc.SelectNodes("//Animals/Animal"))
			{
				newXmlDoc = new XmlDocument();
				var targetNode = newXmlDoc.ImportNode(animalNode, true);
				newXmlDoc.AppendChild(targetNode);
				newXmlDoc.Save(Console.Out);
				Console.WriteLine();
			}
		}

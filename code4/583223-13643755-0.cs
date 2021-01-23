    		StringBuilder xml = new StringBuilder();
			xml.Append("<items>");
			xml.Append("<item id=\"1\" desc=\"one\">");
			xml.Append("<itembody id=\"10\"/>");
			xml.Append("</item>");
			xml.Append("<item id=\"2\" desc=\"two\">");
			xml.Append("<itembody id=\"20\"/>");
			xml.Append("</item>");
			xml.Append("<item id=\"3\" desc=\"three\">");
			xml.Append("<itembody id=\"30\"/>");
			xml.Append("</item>");
			xml.Append("</items>");
				
			using (XmlTextReader tr = new XmlTextReader(new StringReader(xml.ToString())))
			{
				bool canRead = tr.Read();
				while (canRead)
				{
					if ((tr.Name == "item") && tr.IsStartElement())
					{
						Console.WriteLine(tr.GetAttribute("id"));
						Console.WriteLine(tr.GetAttribute("desc"));
						string outerxml = tr.ReadOuterXml();
						Console.WriteLine(outerxml);
						canRead = (outerxml != string.Empty);
					}
					else
					{
						canRead = tr.Read();
					}
				}
			}

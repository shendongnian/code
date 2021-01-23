    public class Foo : IXmlSerializable
	{
		public XmlSchema GetSchema() { return null; }
		public void ReadXml(XmlReader reader)
		{
			if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == GetType().ToString())
			{
				reader.Read();
				if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Bars")
				{
					reader.Read();
					while (reader.MoveToContent() == XmlNodeType.Element && Type.GetType(reader.LocalName).IsSubclassOf(typeof(T)))
					{
						var itemType = Type.GetType(reader.LocalName);
						T item = (T) barType.Assembly.CreateInstance(reader.LocalName);
						item.ReadXml(reader);
						
						reader.Read();
					}
				}
			}
		}
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement(GetType().ToString());
			writer.WriteStartElement("Bars");
			Bar bar = new Bar(); //Localized just for show
	        bar.WriteXml(writer);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

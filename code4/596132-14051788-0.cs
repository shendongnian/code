	public void ReadXml(System.Xml.XmlReader reader)
	{
		reader.Read();
		reader.MoveToContent();
		if (reader.LocalName == "AnotherNode")
		{
			var innerXml = Serializer<AnotherClass>.CreateSerializer();
			Remove = (AnotherClass) innerXml.Deserialize(reader);
			reader.MoveToContent();
		}
		reader.Read();
		// Here is the trick
		if (reader.IsStartElement())
		{
			do
			{
				var innerXml = Serializer<T>.CreateSerializer();
				var obj = (T) innerXml.Deserialize(reader);
				Updates.Add(obj);
			} while (reader.MoveToContent() == XmlNodeType.Element);
		}
	}
	public void WriteXml(System.Xml.XmlWriter writer)
	{
		var removeSerializer = Serializer<RemoveElement>.CreateSerializer();
		removeSerializer.Serialize(writer, Remove);
		if (Updates.Any())
		{
			var innerXml = Serializer<T>.CreateSerializer();
			writer.WriteStartElement("ContentUpdates");
			foreach (var update in Updates)
			{
				innerXml.Serialize(writer, update);
			}
			writer.WriteEndElement();
		}
	}

    public static class ExtensionMethods
	{
		public static bool ReadNextElement(this XmlReader reader)
		{
			while (reader.Read())
				if (reader.NodeType == XmlNodeType.Element)
					return true;
			return false;
		}
	}

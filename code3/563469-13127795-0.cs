	public static string SerializeAnObject(Object item) {
		if (item == null)
			return null;
		var stringBuilder = new StringBuilder();
		var itemType = item.GetType();
		new XmlSerializer(itemType).Serialize(new StringWriter(stringBuilder), item);
		return stringBuilder.ToString();
	}

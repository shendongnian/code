    //added this virtual method
    protected virtual string GetAttributeValue(string attributeName, JsonReader reader)
	{
		return reader.Value.ToString();
	}
    private void ReadElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, XmlNamespaceManager manager)
    {
      if (string.IsNullOrEmpty(propertyName))
        throw new JsonSerializationException("XmlNodeConverter cannot convert JSON with an empty property name to XML.");
      Dictionary<string, string> attributeNameValues = ReadAttributeElements(reader, manager);
      string elementPrefix = MiscellaneousUtils.GetPrefix(propertyName);
      if (propertyName.StartsWith("@"))
      {
        var attributeName = propertyName.Substring(1);
        //Made the change below to use the new method
        //var attributeValue = reader.Value.ToString();
		var attributeValue = GetAttributeValue(attributeName, reader);
        ...
    // Modified to virtual to allow derived class to override.  Added attributeName parameter
    protected virtual string ConvertTokenToXmlValue(string attributeName, JsonReader reader)
    {
      if (reader.TokenType == JsonToken.String)
      {
        return reader.Value.ToString();
      }
      ....

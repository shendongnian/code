    public class DerivedXmlNodeConverter : Newtonsoft.Json.Converters.XmlNodeConverter
    {
	private Dictionary<string, string> _attributeFormatStrings;
	public Dictionary<string, string> AttributeFormatStrings
	{
		get
		{
			if (_attributeFormatStrings == null)
				_attributeFormatStrings = new Dictionary<string,string>();
			return _attributeFormatStrings;
		}
	}
	protected override string GetAttributeValue(string attributeName, JsonReader reader)
	{
		Console.WriteLine("getting attribute value: " + attributeName);
		if (AttributeFormatStrings.ContainsKey(attributeName))
		{
			return string.Format(AttributeFormatStrings[attributeName], reader.Value);
		}
		else
			return base.GetAttributeValue(attributeName, reader);
	}
	protected override string ConvertTokenToXmlValue(string attributeName, JsonReader reader)
	{
		if (AttributeFormatStrings.ContainsKey(attributeName))
		{
			return string.Format(AttributeFormatStrings[attributeName], reader.Value);
		}
		else
			return base.ConvertTokenToXmlValue(attributeName, reader);
	} 
    }

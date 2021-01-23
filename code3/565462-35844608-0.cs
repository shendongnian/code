    public class XmlWrapper
	{
		public static dynamic Convert(XElement parent)
		{
			dynamic output = new ExpandoObject();
			output.Name = parent.Name.LocalName;
			output.Value = parent.Value;
			output.HasAttributes = parent.HasAttributes;
			if (parent.HasAttributes)
			{
				output.Attributes = new List<KeyValuePair<string, string>>();
				foreach (XAttribute attr in parent.Attributes())
				{
					KeyValuePair<string, string> temp = new KeyValuePair<string, string>(attr.Name.LocalName, attr.Value);
					output.Attributes.Add(temp);
				}
			}
			output.HasElements = parent.HasElements;
			if (parent.HasElements)
			{
				output.Elements = new List<dynamic>();
				foreach (XElement element in parent.Elements())
				{
					dynamic temp = Convert(element);
					output.Elements.Add(temp);
				}
			}
			return output;
		}
    }

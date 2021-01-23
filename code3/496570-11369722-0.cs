	public class Event
	{
		[XmlArrayItem(typeof(Data))]
		[XmlArrayItem(typeof(ComplexData))]
		public Data[] EventData;
	}
	
	public class Data
	{
		[XmlAttribute]
		public string Name;
	
		[XmlText]
		public string Value;
	}
	
	public class ComplexData : Data
	{
	}

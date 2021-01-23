	public class Event
	{
		[XmlArrayItem(typeof(Data))]
		[XmlArrayItem(typeof(ComplexData))]
		public object[] EventData;
	}
	
	public class Data
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	
	public class ComplexData
	{
		[XmlAttribute]
		public string Name { get; set; }
		[XmlText(DataType = "hexBinary")]
		public byte[] Encoded { get; set; }
	}

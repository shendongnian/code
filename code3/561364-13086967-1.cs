	[Serializable()]
	[System.Xml.Serialization.XmlRoot("TestRootElement")]
	public class TestRootElement
	{
		[XmlArray("TestList")]
		public List<TestItem> TestList { get; set; }
	}
	[Serializable()]
	[XmlType("TestItem")]
	public class TestItem
	{
		[XmlElement("TestElement")]
		public string TestElement { get; set; }
	}

	[XmlRoot("root")]
	public class MyCustomStructure
	{
		[XmlElement("table1")]
		public Table1Structure[] Table1Array { get; set; }
	}
	
	[XmlRoot("table1")]
	public class Table1Structure
	{
		[XmlAttribute("col1")]
		public string Col1 { get; set; }
		[XmlAttribute("col2")]
		public string Col2 { get; set; }
		[XmlArray("table2Array")]
		[XmlArrayItem("table2")]
		public Table2Structure[] Table2Array { get; set; }
	}
	
	[XmlRoot("table2")]
	public class Table2Structure
	{
		[XmlAttribute("col1")]
		public string Col1 { get; set; }
		[XmlAttribute("col2")]
		public string Col2 { get; set; }
		[XmlArray("table3array")]
		[XmlArrayItem("table3")]
		public Table3Structure[] Table3Array { get; set; }
	}
	
	public class Table3Structure
	{
		[XmlAttribute("col1")]
		public string Col1 { get; set; }
		[XmlAttribute("col2")]
		public string Col2 { get; set; }
	}

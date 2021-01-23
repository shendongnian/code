	public class MyDto
	{
		[XmlAttribute(AttributeName = "complex-attribute")]
		public string MyComplexPropertyAsString
		{
			get { return MyComplexMember.ToString(); }
			set { MyComplexMember.LoadFromString(value); }
		}
		[XmlIgnore]
		public MyComplexMember At { get; set; }
	}

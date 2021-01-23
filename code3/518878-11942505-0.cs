	[XmlRoot("Val")]
	public class DecimalField
	{
		[XmlText()]
		public decimal Value { get; set; }
		[XmlAttribute("Estimate")]
		public bool Estimate { get; set; }
	}

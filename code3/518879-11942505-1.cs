	[XmlRoot("Val")]
	public class DecimalField : IXmlSerializable
	{
		public decimal Value { get; set; }
		public bool Estimate { get; set; }
		
		public void WriteXml(XmlWriter writer)
		{
			if (Estimate == true)
			{
				writer.WriteAttributeString("Estimate", Estimate.ToString());
			}
			
			writer.WriteString(Value.ToString());
		}
		
		public void ReadXml(XmlReader reader)
		{
			if (reader.MoveToAttribute("Estimate") && reader.ReadAttributeValue())
			{
				Estimate = bool.Parse(reader.Value);
			}
			else
			{
				Estimate = false;
			}
			
			reader.MoveToElement();
			Value = reader.ReadElementContentAsDecimal();
		}
		
		public XmlSchema GetSchema()
		{
			return null;
		}
	}

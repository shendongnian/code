		void Main()
		{
			using(var stream = new StringReader(
                      "<Items><Item><IntValue>1</IntValue></Item></Items>"))
			{
				var serializer = new XmlSerializer(typeof(Container));
				
				var items = (Container)serializer.Deserialize(stream);
				
				items.Dump();
			}
		}
		
		[XmlRoot("Items")]
		public class Container
		{
			[XmlElement("Item")]
			public List<Item> Items { get; set; }
		}
		
		public class Item : IXmlSerializable
		{
			public int IntValue{get;set;}
			
			public void WriteXml (XmlWriter writer)
			{
				writer.WriteElementString("IntValue", IntValue.ToString());
			}
		
			public void ReadXml (XmlReader reader)
			{
				var v = reader.ReadElementString();
				// TODO: check and throw appropriate exception
				IntValue = int.Parse(v);
			}
		
			public XmlSchema GetSchema()
			{
				return(null);
			}
		}

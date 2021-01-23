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
		
		public class Item
		{
			[XmlElement("IntValue")]
			public string _IntValue{get;set;}
			
			[XmlIgnore]
			public int IntValue
			{
				get
				{
					// TODO: check and throw appropriate exception
					return Int32.Parse(_IntValue);
				}
			}
		}

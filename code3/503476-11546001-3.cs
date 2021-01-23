	[XmlRoot("Response")]
	public class MyClients
	{
		[XmlArray("Clients")]
		[XmlArrayItem("Client")]
		public List<MyClient> Clients { get; set; }
	}
	
	[XmlRoot("Client")]
	public class MyClient
	{
		[XmlElement("ID")]
		public int ID;
		[XmlElement("Name")]
		public string Name;
		[XmlElement("Age")]
		public int Age;
		[XmlElement("Address")]
		public string Address;
	}

	[XmlRoot("rss")]
	public class RSS
	{
		[XmlAttribute]
		public string version { get; set; }
		public ChannelClass channel { get; set; }
	}
	public class ChannelClass
	{
		public string title { get; set; }
		public string ttl { get; set; }
		public string description { get; set; }
		public string link { get; set; }
		public string copyright { get; set; }
		public string language { get; set; }
		public string pubDate { get; set; }
		[XmlElement]
		public List<ItemClass> item { get; set; }
	}
	public class ItemClass
	{
		public string title { get; set; }
		public string link { get; set; }
		public string description { get; set; }
		public string guid { get; set; }
	}

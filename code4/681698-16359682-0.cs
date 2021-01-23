  	public class Faq2
	{
		public string id { get; set; }
	}
	public class Faq
	{
		public Faq2 faq { get; set; }
	}
	public class RootObject
	{
		public List<Faq> faqs { get; set; }
	}

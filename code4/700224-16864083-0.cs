	public class Links
	{
		public string channel { get; set; }
		public string self { get; set; }
	}
	public class Links2
	{
		public string self { get; set; }
	}
	public class Links3
	{
		public string stream_key { get; set; }
		public string editors { get; set; }
		public string subscriptions { get; set; }
		public string commercial { get; set; }
		public string videos { get; set; }
		public string follows { get; set; }
		public string self { get; set; }
		public string chat { get; set; }
		public string features { get; set; }
	}
	public class Channel
	{
		public string display_name { get; set; }
		public Links3 _links { get; set; }
		public List<object> teams { get; set; }
		public string status { get; set; }
		public string created_at { get; set; }
		public string logo { get; set; }
		public string updated_at { get; set; }
		public object mature { get; set; }
		public object video_banner { get; set; }
		public int _id { get; set; }
		public string background { get; set; }
		public string banner { get; set; }
		public string name { get; set; }
		public string url { get; set; }
		public string game { get; set; }
	}
	public class Stream
	{
		public Links2 _links { get; set; }
		public string broadcaster { get; set; }
		public string preview { get; set; }
		public long _id { get; set; }
		public int viewers { get; set; }
		public Channel channel { get; set; }
		public string name { get; set; }
		public string game { get; set; }
	}
	public class RootObject
	{
		public Links _links { get; set; }
		public Stream stream { get; set; }
	}

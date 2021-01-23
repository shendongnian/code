  	public class User
	{
		public string id { get; set; }
		public string usertype { get; set; }
		public string currenttime { get; set; }
		public string sessionid { get; set; }
	}
	public class Response
	{
		public User user { get; set; }
	}
	public class RootObject
	{
		public string code { get; set; }
		public string message { get; set; }
		public Response response { get; set; }
	}
---
    var obj = JsonConvert.DeserializeObject<RootObject>(json);

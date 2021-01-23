	public class ValidateAbuse
	{
		private Func<List<string>> callback;
		public ValidateAbuse(Func<List<string>> callback)
		{
			this.callback = callback;
		}
		public void Ip(string ip)
		{
			var result = callback();
		}
	}
	public class Server
	{
		public static void Start()
		{
			var validateAbuse = new ValidateAbuse(GetIpAbuseList);
			validateAbuse.Ip(MyIp);
		}
		private static List<string> GetIpAbuseList()
		{
			//return List<string> to ValidateAbuse class and use return value in public void Ip(string ip) method 
		}
	}

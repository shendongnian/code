	public class File
	{
		private List<Setting> settings = new List<Setting>();
		public Tab Tab { get; set; }
		public List<Setting> Settings { get{ return settings; } }
	}
	public class Tab
	{
		public string Main{ get; set;}
		public string Settings{ get; set;}
	}
	public class Setting
	{
		private List<string> options = new List<string>();
		public string Value{ get; set; }
		public List<string> Options{ get{ return options;} }
	}

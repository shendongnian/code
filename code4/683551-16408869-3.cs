    var jObj = JsonConvert.DeserializeObject<RootObject>(text);
    public class Sentence
	{
		public string trans { get; set; }
		public string orig { get; set; }
		public string translit { get; set; }
		public string src_translit { get; set; }
	}
	public class Entry
	{
		public string word { get; set; }
		public List<string> reverse_translation { get; set; }
		public double score { get; set; }
	}
	public class Dict
	{
		public string pos { get; set; }
		public List<string> terms { get; set; }
		public List<Entry> entry { get; set; }
	}
	public class RootObject
	{
		public List<Sentence> sentences { get; set; }
		public List<Dict> dict { get; set; }
		public string src { get; set; }
		public int server_time { get; set; }
	}

    class Movie
	{
		[JsonProperty("title")]
		public List<string> Title { get; set; }
		[JsonProperty("images")]
		public List<string> Images { get; set; }
		[JsonProperty("actors")]
		public List<string> Actor { get; set; }
		[JsonProperty("directors")]
		public List<string> Directors { get; set; }
	}

    class Movie
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonProperty("images")]
		public object Images { get; set; }
		[JsonProperty("actors")]
		public object Actor { get; set; }
		[JsonProperty("directors")]
		public object Directors { get; set; }
	}

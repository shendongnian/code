	public class SearchResults {
		public IList<SearchResult> data { get; set;}
	}
	public class SearchResult {
		public string id { get; set; }
		public string name { get; set; }
		public string category { get; set; }
	}
	var result = fb.Get<SearchResults>(...)

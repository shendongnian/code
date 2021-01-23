	[DataContract]
	public class SearchResults {
		[DataMember(Name = "data")]
		public IList<SearchResult> Data { get; set;}
	}
	[DataContract]
	public class SearchResult {
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "Name")]
		public string Name { get; set; }
		[DataMember(Name = "Category")]
		public string Category { get; set; }
	}

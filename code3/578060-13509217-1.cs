	[JsonObject(MemberSerialization.OptIn)]
	public class Response{
		[JsonProperty]
		public ResponseHeader responseHeader{
			get; set;
		}
		[JsonProperty]
		public ResponseContent response{
			get; set;
		}
	}
	[JsonObject(MemberSerialization.OptIn)]
	public class ResponseHeader{
		[JsonProperty]
		public int Status{
			get; set;
		}
		[JsonProperty]
		public int QTime{
			get; set;
		}
		[JsonProperty]
		public object Params{
			get; set;
		}
	}
	[JsonObject(MemberSerialization.OptIn)]
	public class ResponseContent{
		
		[JsonProperty]
		public int numFound{
			get; set;
		}
		[JsonProperty]
		public int start{
			get; set;
		}
		[JsonProperty]
		public double maxScore{
			get; set;
		}
		[JsonProperty]
		public Document[] docs{
			get; set;
		}
	}
	[JsonObject(MemberSerialization.OptIn)]
	public class Document{
		
		[JsonProperty]
		public string id{
			get; set;
		}
		[JsonProperty]
		public string name{
			get; set;
		}
		[JsonProperty]
		public string email{
			get; set;
		}
		[JsonProperty]
		public DateTime dateTimeCreated{
			get; set;
		}
		[JsonProperty]
		public DateTime dateTimeUploaded{
			get; set;
		}
		[JsonProperty]
		public double score{
			get; set;
		}
	}

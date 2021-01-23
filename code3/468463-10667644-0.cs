    [JsonObject(MemberSerialization.OptIn)]
	public class PlainString
	{
		[JsonProperty]
		public string Data { get; set; }
		public PlainString() { }
		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(this);
		}
		public static PlainString Deserialize(string jsonString)
		{
			return JsonConvert.DeserializeObject<PlainString>(jsonString);
		}
	}

    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
	public class Container
	{
		public Action Action { get; set; }
		[JsonProperty(PropertyName = "Action")]
		public string ActionString
		{
			get
			{
				return Action.ToString();
			}
		}
	}

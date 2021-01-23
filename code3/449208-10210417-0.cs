    [DataContract]
	public class WCFDataTableContract
	{
		[DataMember]
		public byte[] Schema { get; set; }
		[DataMember]
		public byte[] Data { get; set; }
	}

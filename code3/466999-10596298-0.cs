        [DataContract]
	public class CreateSubscribersResultCollection : RequestBase
	{
		[XmlArray("CreatedSubscriberIds")]
		[XmlArrayItem(typeof(long), Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
		public List<long> CreatedSubscriberIds { get; set; }
		[XmlElement("FailedCreatedSubscribers")]
		public string FailedCreatedSubscribers { get; set; }
	}

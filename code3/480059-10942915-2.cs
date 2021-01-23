    using System.Runtime.Serialization;
    [DataContract]
    public class Account
    {
		[DataMember]
		public System.Guid ID { get; set; }
		[DataMember]
		public System.Guid AccountSubTypeID { get; set; }
		[DataMember]
		public Nullable<int> IndustryTypeID { get; set; }
    }

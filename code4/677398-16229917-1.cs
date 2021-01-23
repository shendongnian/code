	[DataContract]
	public class Person
	{
		// This member is serialized.
		[DataMember]
		internal string FullName;
		// This is serialized even though it is private.
		[DataMember]
		private int Age;
		// This is not serialized because the DataMemberAttribute 
		// has not been applied.
		private string MailingAddress;
		// This is not serialized, but the property is.
		private string telephoneNumberValue;
		[DataMember]
		public string TelephoneNumber
		{
			get { return telephoneNumberValue; }
			set { telephoneNumberValue = value; }
		}
	}

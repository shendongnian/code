	[DataContract]
	public class ActionArrayOfUserDto
	{
		public string ActionProperty1 { get; set; }
		public string ActionProperty2 { get; set; }
		// ... the rest of the Action generic class properties
		public UserDto[] UserDtos { get; set; }
	}
	[DataContract]
	public class UserDto
	{
		//UserDto properties...
	}

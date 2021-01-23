	public class Persons
	{
		[XmlElement(ElementName="Persons")]
		public List<Person> PersonsModel { get; set; }
	}
	public class Person
	{
		[XmlElement(ElementName="Id")]
		public int Id { get; set; }
		[XmlElement(ElementName="FirstName")]
		public String FirstName { get; set; }
		[XmlElement(ElementName="LastName")]
		public String LastName { get; set; }
		[XmlElement(ElementName="Addresses")]
		public List<Address> Addresses { get; set; }
	}
	public class Address
	{
		[XmlElement(ElementName="AddressType")]
		public string AddressType { get; set; }
		[XmlElement(ElementName="Street1")]
		public string Street1 { get; set; }
		[XmlElement(ElementName="Street2")]
		public string Street2 { get; set; }
		[XmlElement(ElementName="Street3")]
		public string Street3 { get; set; }
		[XmlElement(ElementName="City")]
		public string City { get; set; }
	}

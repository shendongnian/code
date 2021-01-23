    public class TestContact
	{
		public int ContactID { get; set; }
		public string ContactName { get; set; }
		public List<TestPhone> TestPhones { get; set; }
	}
	public class TestPhone
	{
		public int PhoneId { get; set; }
		public int ContactID { get; set; } // foreign key
		public string Number { get; set; }
	}

	public class Person
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public Person()
		{
			Id = Guid.NewGuid();
		}
		public Person(string firstName, string middleName, string lastName)
		{
			Id = Guid.NewGuid();
			FirstName = firstName;
			MiddleName = middleName;
			LastName = lastName;
		}
	}

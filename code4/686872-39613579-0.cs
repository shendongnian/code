	public class Person
	{
		public string FirstName { get; }
		public string LastName { get; }
		public string FullName => FirstName + LastName;
		public ImmutablePocoSample(string lastName)
		{
			LastName = lastName;
		}
		public ImmutablePocoSample(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}

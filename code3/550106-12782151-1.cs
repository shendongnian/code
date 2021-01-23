	[ServiceContract]
	public class NestedDataService
	{
		[OperationContract]
		public Person FindPerson()
		{
			var person = new Person { Name = "E.M. Ployee" };
			var manager = new Person { Name = "M.A. Nager" };
			manager.Employees = new List<Person>();
			manager.Employees.Add(person);
			person.Manager = manager;
			return person;
		}
	}
	[DataContract]
	public class Person
	{
		[DataMember]
		public String Name { get; set; }
		[DataMember]
		public Person Manager { get; set; }
		[DataMember]
		public List<Person> Employees { get; set; }
	}

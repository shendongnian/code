	public class Person
	{
		public string Name { get; set; }
	}
	public class Teacher : Person
	{
	}
	public class Student : Person
	{
	}
	public static class PersonFactory
	{
		public static T MakePerson<T>(string name) where T: Person, new()
		{
			T person = new T {Name = name};
			return person;
		}
	}

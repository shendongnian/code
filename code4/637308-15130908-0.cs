	using BasePerson = BaseLibrary.Person;
	public class Person : BasePerson
	{
		public virtual ICollection Vehicles { get; set; }
	}

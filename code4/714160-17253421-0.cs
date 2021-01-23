	public class EmployeeCollection : IEnumerable<Employee>
	{
		public List<Employee> Employees { get; set; }
		public EmployeeCollection()
		{
			Employees = new List<Employee>();
		}
		public IEnumerator<Employee> GetEnumerator()
		{
			return Employees.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return Employees.GetEnumerator();
		}
	}
	public class X
	{
		static void Main(string[] args)
		{
			EmployeeCollection empcoll = new EmployeeCollection();
			empcoll.Employees.Add(new Employee("Fatima", 57));
			empcoll.Employees.Add(new Employee("Evangeline", 52));
			empcoll.Employees.Add(new Employee("Damien", 49));
			empcoll.Employees.Add(new Employee("Cameroon", 55));
			empcoll.Employees.Add(new Employee("Babu", 24));
			Console.Write("Senior Employees \n");
			foreach (Employee anEmp in empcoll.Where(n => n.Age > 50))
			{
				Console.WriteLine("   " + anEmp.Name + "   " + anEmp.Age);
			}
			Console.ReadKey(true);
		}
	}

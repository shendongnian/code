	public class Employee
	{
		private static readonly IList<Employee> _allEmployees = new List<Employee>();
		public Employee()
		{
			// constructor stuff
			_allEmployees.Add(this);
		}
	}

    public class Employee
    {
		public Employees employees { get; set; }
		public int employeeID { get; set; }
		public int? parentEmployeeID { get; set; }
		public string Name { get; set; }
		public string Position { get; set; }
		public Employee Boss 
		{
			get 
			{
				return employees.FirstOrDefault(e => e.employeeID == this.parentEmployeeID); 
			}
		}
		public IEnumerable<Employee> Subordinates 
		{ 
			get
			{
				return employees.Where(e => e.parentEmployeeID == this.employeeID);
			}
		}
	}

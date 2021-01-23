	void Main()
	{
		var emps = new List<Employee>
		{
			new Employee { SupervisorId = 1, EmployeeId = 5 },
			new Employee { SupervisorId = 1, EmployeeId = 6 },
			new Employee { SupervisorId = 1, EmployeeId = 7 },
			new Employee { SupervisorId = 2, EmployeeId = 5 },
			new Employee { SupervisorId = 2, EmployeeId = 6 },
			new Employee { SupervisorId = 3, EmployeeId = 7 },
			new Employee { SupervisorId = 4, EmployeeId = 6 },
			new Employee { SupervisorId = 4, EmployeeId = 8 }
		};
		
		FindSuperVisorId(emps, new List<int>{5,6}).Dump();
	}
	
	int? FindSuperVisorId(List<Employee> employees, List<int> employeEmployeeIds)
	{
		var nested = employees.Select(e => e.SupervisorId).Distinct().Select (
			s => new 
				{
					SupervisorId=s, 
					EmployeEmployeeIds=employees.Where (e => e.SupervisorId == s).Select (e => e.EmployeeId).Distinct() 
				});
		
		var supervisorIds = nested.Where (
			n => n.EmployeEmployeeIds.OrderBy (ei => ei).SequenceEqual(employeEmployeeIds.OrderBy (i => i)) ).Select (n => n.SupervisorId).Distinct();
		
		if(supervisorIds.Count () == 1)
		{
			return supervisorIds.Single ();
		}
		
		return null;
	}
	
	class Employee
	{
		public int SupervisorId { get; set; }
		public int EmployeeId { get; set; }
	}

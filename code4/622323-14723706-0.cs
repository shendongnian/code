	class Employee
	{
		private int empId;
		private int empSalary;
		private string empName;
		private int empAge;
		
		public void SetEmployeeID(int id)
		{
			empId = id; //Mutator
		}
		
		public void SetEmployeeSalary(int sal)
		{
			empSalary = sal;  //Mutator
		}
		
		public int GetEmployeeID()
		{
			return empId;  //Accessor
		}
		
		public int GetEmployeeSalary()
		{
			return empSalary;  //Accessor
		}
		
		public string EmployeeName
		{
			get { return empName; }   //Accessor
			set { empName = value; }  //Mutator
		}
		
		public int EmployeeAge
		{
			get { return empAge; }  //Accessor
			set { empAge = value; } //Mutator
		}
		
		public override string ToString()
		{
			return this.GetEmployeeID() + " : " + 
				this.EmployeeName + " : " + 
				this.EmployeeAge + " : " + 
				this.GetEmployeeSalary();
		}
		
		
	}

    public class EmployeeFactory
    {
        private readonly IList<Employee> empList;
        public EmployeeFactory(IList<Employee> empList)
        {
            // guard clause to protect from null lists
            this.empList = empList;
        }
        public Employee Create(/* optional employee data used to instatiate */)
        {
            var newEmp = new Employee();
            this.empList.Add(newEmp);
            return newEmp;
        }
    }

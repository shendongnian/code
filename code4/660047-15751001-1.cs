    class Employee
    {
        public int EmpId { get; set; }
        public float Salary { get; set; }
        public string Designation { get; set; }
    }
    class Employees
    {
        List<Employee> EmpList = new List<Employee>();
        public Employee this[int empId]
        {
            get
            {
                return EmpList.Find(x => x.EmpId == empId);
            }
        }
    }

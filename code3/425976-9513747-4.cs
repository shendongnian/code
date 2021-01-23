    public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public Department EmpDepartment { get; set; }
        }
        public class Department
        {
            public string Name { get; set; }
        }

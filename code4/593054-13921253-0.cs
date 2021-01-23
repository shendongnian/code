    public class Employees
    {
        public int employeeID { get; set; }
        public int? parentEmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Employees> subEmp { get; set; }
    }

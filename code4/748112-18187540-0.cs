    public class Employee
    {
        public int EmployeeID {get;set;}
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get { return LastName + ", " + FirstName + " " + MiddleName; } }
    
        public Employee(IDataRecord record)
        {
            this.EmployeeID = Convert.ToInt32(record["EmployeeID"]);
            this.LastName = record["LastName"].ToString();
            this.FirstName = record["FirstName"].ToString();
            this.MiddleName = record["MiddleName"].ToString();
        }
    }

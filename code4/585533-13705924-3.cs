    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

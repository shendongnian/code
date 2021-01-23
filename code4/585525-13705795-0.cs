    public class Attendance
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; } // THIS is the foreign key.
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
    }

    public class Attendance
    {
        public int Id { get; set; }
        //This exposes the foreign key on attendance
        public int EmployeeId {get; set;}
        public Employee Employee { get; set; } //This is the foreign key
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
    }

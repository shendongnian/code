    public class Schedule
    {
        public int Id { get; set; }
        [InverseProperty("Schedule")]
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
    public class Appointment
    {
        public int Id { get; set; }
        public Schedule Schedule { get; set; }
    }

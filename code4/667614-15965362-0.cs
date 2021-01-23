    public class Appointment
    {
        [DataType(DataType.Date)]
        public DateTime? AppointmentDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime? EndTime { get; set; }
    }

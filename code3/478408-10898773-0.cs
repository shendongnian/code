    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
    public class AppointmentMap : ClassMap<Appointment>
    {
        public AppointmentMap()
        {
            Map(x => x.Start, "StartDateStringColumn");
            Map(x => x.End, "EndDateStringColumn");
        }
    }

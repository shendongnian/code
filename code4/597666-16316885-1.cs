    class Program
    {
        static void Main(string[] args)
        {
            List<appointments> appointment = new List<appointments>();
    
            appointment.Add(new appointments() { Appointment = "meeting", Start = new DateTime(2013, 01, 02), Location = "office" });
            appointment.Add(new appointments() { Appointment = "lunch", Start = new DateTime(2013, 01, 07), Location = "cafe" });
            appointment.Add(new appointments() { Appointment = "meeting", Start = new DateTime(2013, 01, 08), Location = "cityhall" });
            appointment.Add(new appointments() { Appointment = "dentist", Start = new DateTime(2013, 01, 14), Location = "dentist" });
    
            foreach (var appt in GetAppointmentsByWeek(appointment, 1))
                Console.WriteLine(appt.Appointment);
    
            Console.ReadLine();
        }
    
        private static IEnumerable<appointments> GetAppointmentsByWeek(List<appointments> appts, int weeknum)
        {
            if (weeknum < 0)
                return new appointments[] { };
    
            var ordered = appts.OrderBy(a => a.Start.Ticks);           
            var start = ordered.First().Start.AddDays(weeknum * 7);
            var end = start.AddDays(7);
            return ordered.Where(o => o.Start.Ticks >= start.Ticks && o.Start.Ticks <= end.Ticks);
        }
    }
    
    public class appointments
    {
        public string Appointment { get; set; }
        public DateTime Start { get; set; }
        public string Location { get; set; }
    }

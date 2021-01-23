    public class Person
    {
        public List<Appointment> Appointments { get; private set; }
        ...
        public Person()
        {
            Appointments = new List<Appointment>();
        }
    }
    public class Appointment
    {
        public Person Person { get; set; } // Only if you need this relation from
        ...
    }

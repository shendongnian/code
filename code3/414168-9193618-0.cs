    class Person
    {
        public int id { get; set; }
        public String name { get; set; }
    }
    class Appointment
    {
        public int id { get; set; }
        public Date when { get; set; }
        public Person who { get; set; }
    }

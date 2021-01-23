        public class Client
        {
            public DateTime AppointmentDate { get; set; }
            public int TIN { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }
        private Client _client = new Client();
        public bool EligibleAppointment()
        {
            _client.AppointmentDate = DateTime.Today; // Or something. This way you'll assign DateTime.Today to the AppointmentDate of this specific _client object.
            return _client.AppointmentDate > DateTime.MinValue; // Or whatever.
        }

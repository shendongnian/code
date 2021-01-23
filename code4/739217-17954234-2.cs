    DateTime lastMonth = DateTime.Today.AddMonths(-1);
    int selectedUserId = 2; 
    var notes = new List<Note>(
        new Note[] {
            new Note() { 
                AppointmentDate = new DateTime(2013,7,30){}, 
                IDAppointment = 1, IDUser = 1, DurationInHours = 1
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,30){}, 
                IDAppointment = 1, IDUser = 1, DurationInHours = 2
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,30){}, 
                IDAppointment = 1, IDUser = 1, DurationInHours = 3
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,28){}, 
                IDAppointment = 2, IDUser =  2, DurationInHours = 2
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,28){}, 
                IDAppointment = 2, IDUser =  2, DurationInHours = 3
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,27){}, 
                IDAppointment = 2, IDUser =  2, DurationI nHours = 4
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,26){}, 
                IDAppointment = 3, IDUser =  3, DurationInHours = 3
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,25){}, 
                IDAppointment = 3, IDUser =  3, DurationInHours = 4
            },
            new Note() {
                AppointmentDate = new DateTime(2013,7,24){}, 
                IDAppointment = 3, IDUser =  3, DurationInHours = 5
            }
        }
    );
    var results = from n in notes
                  group n by new {n.IDUser, n.IDAppointment, n.AppointmentDate}
                  into g
                  where g.Key.AppointmentDate > lastMonth && 
                        g.Key.IDUser == selectedUserId
                  select new {
                      g.Key.IDAppointment, 
                      g.Key.IDUser, 
                      TotalHours = g.Sum(n => n.DurationInHours)
                  };

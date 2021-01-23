    var Times = new List<AppointmentTime>();
    var ConcurrentAppointments = 10;
    Times.AddRange(new[]{
        new AppointmentTime()
        {
            Count = 0,
            Time = new DateTime(2012, 12, 1, 1, 30, 0)
        },
        new AppointmentTime()
        {
            Count = 0,
            Time = new DateTime(2012, 12, 1, 13, 5, 0)
        },
        new AppointmentTime()
        {
            Count = 0,
            Time = new DateTime(2012, 12, 1, 11, 0, 0)
        }});
    var minTime = new TimeSpan(13, 0, 0);
    var maxTime = new TimeSpan(25, 0, 0);
    //returns the AppointmentTime with the 01:30 AM
    var nextAvailableTime = Times.OrderBy(i => i.Time).FirstOrDefault(i => i.Count < ConcurrentAppointments &&
        i.Time.TimeOfDay.TotalSeconds >= Math.Min(maxTime.TotalSeconds % (3600 * 24), minTime.TotalSeconds)
        );

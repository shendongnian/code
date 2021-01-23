    DateTime lastMonth = DateTime.Today.AddMonths(-1);
    int userId = 1 // TODO: FIX
    var result = context.Notes
                        .Where(n => n.AppointmentDate > lastMonth
                                 && n.IDUser = userId)
                        .GroupBy(n => new { n.IDUser, n.IDAppointment, n.AppointmentDate})
                        .Select(g => new {
                                       g.Key.IDAppointment,
                                       g.Key.IDUser,
                                       g.Sum(n => n.DurationInHours)});

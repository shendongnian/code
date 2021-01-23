    var result = context.Notes
                        .Where(n => [Your where clause])
                        .GroupBy(n => new { n.IDUser, n.IDAppointment, n.AppointmentDate})
                        .Select(g => new {
                                       g.Key.IDAppointment,
                                       g.Key.IDUser,
                                       g.Sum(n => n.DurationInHours)});

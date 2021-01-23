    CalendarView calendarView = new CalendarView(dtStart, dtEnd);
    var Appointments = service.FindAppointments(WellKnownFolderName.Calendar, calendarView);
    foreach (Appointment app in items)
    {
        if (app.Body.Text.Trim() == "Timetable")
        {
            app.Delete(DeleteMode.HardDelete);
        }
    }

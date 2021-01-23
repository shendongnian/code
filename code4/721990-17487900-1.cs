    using Microsoft.Exchange.WebServices.Data;
    DateTime startTime = new DateTime(2013, 1, 1);
    DateTime endTime = new DateTime(2013, 12, 31);
    
    var cal = new FolderId(WellKnownFolderName.Calendar, new Mailbox("other user's email"));
    var calendarView = new CalendarView(startTime.Date, endTime.Date.AddDays(1));
    foreach (var appointmentItem in service.FindAppointments(cal, calendarView))
    {
        Console.WriteLine(appointmentItem.Subject);
    }

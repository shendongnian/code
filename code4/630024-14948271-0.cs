    var PacktAppointmentItem = (Microsoft.Office.Interop.Outlook.AppointmentItem)Globals.ThisAddIn.Application.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
    PacktAppointmentItem.Subject = "Test Meeting";
    PacktAppointmentItem.Location = "My Room";
    PacktAppointmentItem.Start = DateTime.Now;
    PacktAppointmentItem.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
    PacktAppointmentItem.End = DateTime.Now.AddHours(1.0);
    PacktAppointmentItem.Body = "Test Meeting";
    PacktAppointmentItem.RequiredAttendees = String.Join(";", rooms);
    PacktAppointmentItem.Display(true);

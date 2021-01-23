    Outlook.Folder folder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox) as Outlook.Folder;
    string filter = "[MessageClass] = 'IPM.Schedule.Meeting.Request'";
    Outlook.Items items = folder.Items.Restrict(filter);
    foreach (Outlook.MeetingItem request in items)
    {
    	Outlook.AppointmentItem appt =	request.GetAssociatedAppointment(false);
    	if (appt != null)	
    		Debug.WriteLine(appt.Subject);
    }

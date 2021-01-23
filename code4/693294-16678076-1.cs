        using Outlook = Microsoft.Office.Interop.Outlook;
        ....
        Outlook.AppointmentItem app;
        Outlook.MailItem mi;
        String loc;
        .....
        
        app = (Outlook.AppointmentItem)mi;
        loc = app.Location;
        //  or
        loc = ((Outlook.AppointmentItem)mi).Location;

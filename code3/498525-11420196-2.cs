    foreach (var item in query)
    {
        var app = c1Schedule1.DataStorage.AppointmentStorage.Appointments.Add();
        app.Subject = item.Name;
        app.Start = item.Start;
        if (item.Finish != null)
        {
            app.Finish = item.Finish.Value;
        }
        if (item.Duration != null)
        {
            app.Duration = item.Duration.Value;
        }
    }

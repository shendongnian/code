            Appointment apt = schedulerControl1.Storage.CreateAppointment(AppointmentType.Pattern);
            apt.Start = DateTime.Now;
            apt.End = apt.Start.AddHours(2);
            apt.Subject = "My Subject";
            apt.Location = "My Location";
            apt.Description = "My Description";
            apt.RecurrenceInfo.Type = RecurrenceType.Daily;
            schedulerControl1.Storage.AppointmentStorage.Add(apt);

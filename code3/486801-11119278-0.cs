    public void addAppointments(String subject,String body,DateTime startTime,DateTime endTime,String location) 
    {
        Appointment app = new Appointment(_service);
        app.Subject = subject;
        app.Body = body;
        app.Start = startTime;
        app.End = endTime;
        app.Location = location;
        //DayOfTheWeek[] days = new DayOfTheWeek[] { DayOfTheWeek.Saturday };
        //app.Recurrence = new Recurrence.WeeklyPattern(app.Start.Date, 1, days);
        //app.Recurrence.StartDate = app.Start.Date;
        //app.Recurrence.NumberOfOccurrences = 3;
        
        app.Save();
    }

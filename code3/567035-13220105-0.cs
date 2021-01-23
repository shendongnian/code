    //Create a reminder
    Reminder myReminder = new Reminder("buy milk");
    myReminder.Title = "Buy Milk";
    myReminder.Content = "Don't forget to buy milk!";
    myReminder.BeginTime = DateTime.Now.AddSeconds(10);
    myReminder.ExpirationTime = DateTime.Now.AddSeconds(15);
    myReminder.RecurrenceType = RecurrenceInterval.None;
    myReminder.NavigationUri = new Uri("/MainPage.xaml?fromReminder=1",         UriKind.Relative);
    //Add the reminder to the ScheduledActionService
    ScheduledActionService.Add(myReminder);

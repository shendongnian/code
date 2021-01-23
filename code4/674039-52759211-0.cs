           new ClientSecrets
           {
               ClientId = "381422642478-tg5s8crg6j1atn259u0aptnltrhmlc24.apps.googleusercontent.com",
               ClientSecret = "7yxk_DOKRQv7XNB1rTF5FM2j",
           },
           new[] { CalendarService.Scope.Calendar },
           "user",
               CancellationToken.None).Result;
            // Create the service.
            var service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });
             DateTime start = DateTime.Now;
            DateTime end = start + TimeSpan.FromMinutes(30);
            DateTime initiate = DateTime.Now;
            DateTime ending = start + TimeSpan.FromMinutes(30);
            start = DateTime.SpecifyKind(start, DateTimeKind.Local);
            end = DateTime.SpecifyKind(end, DateTimeKind.Local);
            var myEvent = new Event
            {
                Summary = "Google I/O 2015",
                Location = "800 Howard St., San Francisco, CA 94103",
                Description = "A chance to hear more about Google's developer products.",
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2018-10-12T09:00:00-07:00"),
                    TimeZone = "America/Los_Angeles",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2018-10-12T17:00:00-07:00"),
                    TimeZone = "America/Los_Angeles",
                },
                Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
                Attendees = new List<EventAttendee>
                {
                new EventAttendee { Email = "wgcu418@gmail.com"}
                },
            };
        var recurringEvent = service.Events.Insert(myEvent, "primary");
        recurringEvent.SendNotifications = true;
            recurringEvent.Execute();

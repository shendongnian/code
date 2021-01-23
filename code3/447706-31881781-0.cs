                //insert event
            Event newEvent = new Event()
            {
                Summary = "5ummary",
                Location = "location avenue",
                Description = "description",
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2015-08-06T09:00:00-07:00"),
                    TimeZone = "America/Los_Angeles",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse("2015-08-06T17:00:00-07:00"),
                    TimeZone = "America/Los_Angeles",
                },
            };
            // Define parameters of request.
            String calendarId = "primary";
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event createdEvent = request.Execute();
            Console.WriteLine("Event created: {0}", createdEvent.HtmlLink);

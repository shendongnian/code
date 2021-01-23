    public static void GCalAdd(string summary, string location, string description, DateTime start, DateTime end, List<EventAttendee> attendees)
    {
        try
        {
            var provider = new NativeApplicationClient(GoogleAuthenticationServer.Description)
            {
                ClientIdentifier = ClientCredentials.ClientID,
                ClientSecret = ClientCredentials.ClientSecret
            };
            var auth = new OAuth2Authenticator<NativeApplicationClient>(provider, GetAuthentication);
            var service = new CalendarService(auth);
            start = start.ToUniversalTime();
            end = end.ToUniversalTime();
            var curTimeZone = TimeZone.CurrentTimeZone;
            var currentOffset = curTimeZone.GetUtcOffset(DateTime.Now);
            var offsetString = currentOffset.ToString();
            start = curTimeZone.ToUniversalTime(start);
            end = curTimeZone.ToUniversalTime(end);
            var st = start.ToString("yyyy-MM-ddThh:mm:ss.000" + offsetString);
            var ed = end.ToString("yyyy-MM-ddThh:mm:ss.000" + offsetString);
            var evt = new Event
            {
                Summary = summary,
                Location = location,
                Description = description,
                Start = new EventDateTime { DateTime = st },
                End = new EventDateTime { DateTime = ed },
                Attendees = attendees,
            };
            var insert = service.Events.Insert(evt, "primary").Fetch();
            if (insert != null)
            {
                MessageBox.Show(@"calendar item inserted");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }
    }

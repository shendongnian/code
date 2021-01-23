	public static void GCalAdd(string summary, string location, string description,
		DateTime start, DateTime end, List<EventAttendee> attendees)
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
			var curTimeZone = TimeZone.CurrentTimeZone;
			var dateOffsetStart = new DateTimeOffset(start, curTimeZone.GetUtcOffset(start));
			var dateOffsetEnd = new DateTimeOffset(end, curTimeZone.GetUtcOffset(end));
			var startTimeString = dateOffsetStart.ToString("o");
			var endTimeString = dateOffsetEnd.ToString("o");
			var evt = new Event
			{
				Summary = summary,
				Location = location,
				Description = description,
				Start = new EventDateTime { DateTime = startTimeString },
				End = new EventDateTime { DateTime = endTimeString },
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

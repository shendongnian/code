    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Services;
    using System.IO;
    namespace Test.GoogleCalendar
    {
        class Program
        {
            static void Main(string[] args)
            {
                GoogleCredential credential;
                using (var stream = new FileStream("credential.json", FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream).CreateScoped(CalendarService.Scope.Calendar);
                }
                // Create Google Calendar API service.
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Test Calendar Reader",
                });
                var calendars = service.CalendarList.List().Execute().Items;
                foreach (CalendarListEntry calendar in calendars)
                {
                    var events = service.Events.List(calendar.Id).Execute();
                }          
            }
        }
    }

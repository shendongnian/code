    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);//You version
    service.Credentials = new WebCredentials("user1@contoso.com", "password");
    service.AutodiscoverUrl("user1@contoso.com", RedirectionUrlValidationCallback);
    string email = "TEST@YOUR.COM";
        
    // Get User Availability after 6 months 
    AttendeeInfo attendee = new AttendeeInfo(email);
    var attnds = new List<AttendeeInfo>();
    attnds.Add(attendee);
    var freeTime = service.GetUserAvailability(attnds, new 
    TimeWindow(DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(6).AddDays(1)), AvailabilityData.FreeBusyAndSuggestions);
    //if you receive result with error then there is a big possibility that the email is not right
    if(freetimes.AttendeesAvailability.OverallResult == ServiceResult.Error)
    {
         return false;
    }
    return true;
 

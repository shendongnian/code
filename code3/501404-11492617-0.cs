    public class MyClassGetQueryString
    {
    
        private const string Attendees = "attendees";
        private const string Speakers = "speakers";
    
        public string MyAttendees()
        {
            return Request.QueryString[MyClassGetQueryString.Attendees] ?? string.Empty;
        }
    
        public string MySpeakers()
        {
            return Request.QueryString[MyClassGetQueryString.Speakers] ?? string.Empty;
        }
    
        public string[] MyAttendeesParts()
        {
            return this.MyAttendees().Split('.');
        } 
    
        public string[] MySpeakersParts()
        {
            return this.MySpeakers().Split('.');
        } 
    }

    public enum ActivityType
    {
        Swimming = 1,
        Biking = 2,
        Basketball = 3,
        Soccer = 4
    }
    
    public class Booking
    {
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
    
        public Activity Activity { get; set; }
    
        public bool ValidateBooking()
        {
            // put logic here to ensure that the booking times fall within the activity start and end time
            return true;
        }
    }
    
    public class Activity
    {
        public ActivityType ActivityType { get; set; }
        public DateTime ActivityStartTime { get; set; }
        public DateTime ActivityEndTime { get; set; }
    }

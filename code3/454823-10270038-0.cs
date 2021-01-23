     public class Booking
        {
            public enum ActivityType
            {
                Swimming = 1,
                Biking = 2,
                Basketball = 3,
                Soccer = 4
            }
    
    
            public DateTime BookingStart { get; set; }
            public DateTime BookingEnd { get; set; }
            public ActivityType Activity { get; set; }
        }

    public class MyObject {
        public TimeZone UserTimeZone { get; set; }
        public DateTime EventDateUTC { get; set; }
        public DateTime EventDateUserTime {
            get {
                // Calculate time based on EventDateUTC and UserTimeZone
            }
        }
    }

    // You want class names to be Upper-case
    public class ScheduleDataViewModel 
    {
        public ApptClient ClientData { get; set; } 
        public ApptCounties Counties { get; set; }
        public ScheduleDataViewModel()
        {
            ClientData = new ApptClient(); 
            Counties = new ApptCounties();
        }
    }

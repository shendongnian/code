    public class MyObject
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double ProgressValue { get; set; }
        private System.Timers.Timer TimeChecker;
        public MyObject()
        {
             // 5 Minutes = 5 * 60 Seconds = 5 * 60 * 1000 Milliseconds
             TimeChecker = new Timer(300000);
             TimeChecker.Elapsed += CheckTimes;
        }
        public CheckTimes()
        {
             // Check StartTime and EndTime to decide whether to enable the slider or not.
             if(...)
             {
                  // Here you can add the appropriate value to indicate the current progress
                  ProgressValue == ....;
             }
             else
                  ProgressValue == ....;
        }
    }

    public class ClassWithDelegate
    {
        public delegate void ProgressReportEventHandler();
        public static ProgressReportEventHandler ProgressReport { get; set; };
    
        private void DoWorkWithItem(object threadContext)
        {
           // angry code
        
           if (ProgressReport != null)
              ProgressReport();
        }
    }
    
    public class Subscriber
    {
        public Subscriber()
        {
             ClassWithDelegate.ProgressReport += ProgressReport;         
        }
    
        public void ProgressReport()
        {
            //todo
        }
    }

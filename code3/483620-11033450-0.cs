      public class Global : System.Web.HttpApplication
      {
        public static ISchedulerFactory Factory;
        public static IScheduler Scheduler;
    
        protected void Application_Start(object sender, EventArgs e)
        {
          Factory = new StdSchedulerFactory();
          Scheduler = Factory.GetScheduler();
        }
      }

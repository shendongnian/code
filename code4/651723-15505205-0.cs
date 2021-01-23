    public class MyService : IMyService
    {
        Logger log;
    
        public MyService()
        {
            log = LogManager.GetLogger(this.GetType().FullName);
        }
    
        [Timing]
        public virtual string GetString()
        {
            log.Info("log me!!");
            return "Cool string !!!!";
        }
    
        public string GetUnInterceptString()
        {
            return "Not intercepted";
        }
    }

    public class UserService1 : System.ServiceProcess.ServiceBase  
    {
        
        public UserService1() 
        {
            this.ServiceName = "MyService2";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }
        public static void Main()
        {
            System.ServiceProcess.ServiceBase.Run(new UserService1());
        }
        protected override void OnStart(string[] args)
        {
            // Insert code here to define processing.
        }
        protected override void OnStop()
        { 
            // Whatever is required to stop processing
        }
    }

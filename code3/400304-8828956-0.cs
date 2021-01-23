    public class Skeduler
    {
        private static Skeduler instance;
        public static Skeduler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Skeduler();
                }
                return instance;
            }
        }
        public delegate void SendRestartX();
        public event SendRestartX SendRestart;
        public void doSendRestart()
        {
            if (SendRestart!=null)
                SendRestart();
        }
        //(Job Methods & Logics Goes Here)
     }
    public class RestartJob : IJob
    {
        //Required
        public RestartJob()
        {
        }
        public virtual void Execute(IJobExecutionContext context)
        {
            Skeduler.Instance.doSendRestart();
        }
    }

    using System;
    using System.ServiceModel;
    using System.ServiceProcess;
    namespace MyService
    {
       public class MyWindowsService:ServiceBase
       {
        public ServiceHost serviceHost = null;
        private static System.Timers.Timer scheduledTimer;
        public MyWindowsService()
        {
            ServiceName = "MyService";
            //Additional Initilizing code.
        }
        public static void Main()
        {
            ServiceBase.Run(new MyWindowsService());
        }
        protected override void OnStart(string[] args)
        {
            scheduledTimer = new System.Timers.Timer();
            scheduledTimer.AutoReset = true;
            scheduledTimer.Enabled = true;
            scheduledTimer.Interval = 5000;
            scheduledTimer.Elapsed += new System.Timers.ElapsedEventHandler(scheduledTimer_Elapsed);
            scheduledTimer.Start();
        }
        void scheduledTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //DO CHECK.
        }
        protected override void OnStop()
        {
            if (scheduledTimer != null)
            {
                scheduledTimer.Stop();
                scheduledTimer.Elapsed -= scheduledTimer_Elapsed;
                scheduledTimer.Dispose();
                scheduledTimer = null;
            }
        }
        private void InitializeComponent()
        {
            this.ServiceName = "MyService";
        }
    }

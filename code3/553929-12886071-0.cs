    namespace MyServiceApp
    {
        public class MyService : ServiceBase
        {
            private System.Timers.Timer timer;
            protected override void OnStart(string[] args)
            {
                this.timer = new System.Timers.Timer(30000D);  // 30000 milliseconds = 30 seconds
                this.timer.AutoReset = true;
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
                this.timer.Start();
            }
            protected override void OnStop()
            {
                this.timer.Stop();
                this.timer = null;
            }
            private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                MyServiceApp.ServiceWork.Main(); // my separate static method for do work
            }
            public MyService()
            {
                this.ServiceName = "MyService";
            }
            // service entry point
            static void Main()
            {
                System.ServiceProcess.ServiceBase.Run(new MyService());
            }
        }
    }

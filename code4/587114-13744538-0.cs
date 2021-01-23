    namespace Mailer
    {
      public partial class Mailer : ServiceBase
      {
        System.Timers.Timer createOrderTimer;
        public Mailer()
        {
          InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
          createOrderTimer = new System.Timers.Timer();                      
          createOrderTimer.Elapsed += new  System.Timers.ElapsedEventHandler(sendmail);
          createOrderTimer.Interval = 900000; // 15 min
          createOrderTimer.Enabled = true;
          createOrderTimer.AutoReset = true;                      
          createOrderTimer.Start();
        }
    
        protected void sendmail(object sender, System.Timers.ElapsedEventArgs args)
        {
          //code to send email.
        }
    
        protected override void OnStop() {  }
      }
    }

    public partial class GBBInvService : ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(GBBInvService));
        System.Timers.Timer timer = new System.Timers.Timer();
        //private volatile bool _requestStop=false; // no _requestStop
        private ManualResetEventSlim resetEvent = new ManualResetEventSlim(false);
        
        
        public GBBInvService()
        {
            InitializeComponent();
        }
        
        protected override void OnStart(string[] args)
        {
            //_requestStop = false;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 18000;
            timer.Enabled = true;
            timer.Start();
            log.Info("GBBInvService Service Started");
        }
        
        protected override void OnStop()
        {
            //log.Info("inside stop"); 
            //if (!_requestStop)
            //{
            //    log.Info("Stop not requested");
            //    timer.Start();
            //}    
            //else
            //{
            //    log.Info("On Stop Called");
            //    WaitUntilProcessCompleted();
            //}
            
            WaitUntilProcessingCompleted();
            log.Info("GBBInvService Service Stopped");
        }
        
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            log.Info("Timer elapsed at " + Convert.ToString(e.SignalTime)); 
            InvProcessing();
        }
        
        private void InvProcessing()
        {
            try
            {
                resetEvent.Reset();
                //*Processing here*
        
            }
            catch (Exception ex)
            {
                resetEvent.Set();
                log.Error(ex.Message); 
            }
        }
        
        
        private void WaitUntilProcessCompleted()
        {
            resetEvent.Wait();
        }
    }

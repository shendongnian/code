         public partial class Service1 : ServiceBase
    {
        private Timer _timer;
        private DateTime _lastRun = DateTime.Now;
    
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
    
            _timer = new Timer(10 * 60 * 1000); // every 10 minutes
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            Shell Distribute= new Shell();
            Distribute.Distribute();
    _timer.start();//this line was missed in my original code
        }
    
        protected override void OnStop()
        {
            this.ExitCode = 0;
            base.OnStop();
    
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           //if (_lastRun.Date < DateTime.Now.Date)
            //{
                
    try
    {
    _timer.Stop();
    Shell Distribute= new Shell();
    Distribute.Distribute();
    }
    catch(exception ex)
    {}
    finally
    {
           
                _timer.Start();
    }
             //}
            }
    
        }
    }

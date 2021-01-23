    public partial class Service1 : ServiceBase
    {
        ServiceHost _host;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Type serviceType = typeof(MyWcfService.Service1);
            _host = new ServiceHost(serviceType);
            _host.Open();
        }
        protected override void OnStop()
        {
            _host.Close();
        }
        public void OnDebugMode_Start()
        {
             OnStart(null);
        }
         public void OnDebugMode_Stop()
         {
             OnStop();
         }
    }

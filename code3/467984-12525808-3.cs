        partial class PrintMonitorService : ServiceBase
        {
        private readonly PrintMonitorServiceManager _serviceManager;
        public PrintMonitorService()
        {
            InitializeComponent();
            _serviceManager = new PrintMonitorServiceManager();
        }
        protected override void OnStart(string[] args)
        {
            _serviceManager.StartHosting(args);
        }
        protected override void OnStop()
        {
            _serviceManager.StopHosting();
        }

    partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] arguments)
        {
             base.OnStart(arguments);
        }
        protected override void OnStop()
        {
            base.OnStop();
        }
        protected override void OnShutdown()
        {
            base.OnShutdown();
        }
    }

    partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
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

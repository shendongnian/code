    [RunInstallerAttribute(true)]
    public class YOUR_PROGRAM : ServiceBase
    {
        public YOUR_PROGRAM()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            Start();
        }
    
        protected override void OnStop()
        {
            //Stop Logic Here
        }
    
        public void Start()
        {
            //Start Logic here
        }
    }

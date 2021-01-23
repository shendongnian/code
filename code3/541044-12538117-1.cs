    public partial class App : Application
    {
        public App()
        {
            StyleManager.ApplicationTheme =new Windows7Theme();
            InitializeComponent();
        }
    
        public static void EnsureApplicationResources()
        {
            if (Application.Current == null)
            {
                // create the Application object
                new App {ShutdownMode = ShutdownMode.OnExplicitShutdown};                                
            }
        }
    
        protected override void OnExit(ExitEventArgs e)
        {
            if(Current != null)
                Current.Shutdown();
    
            base.OnExit(e);
        }
    }

        [STAThread]
        static void Main(string[] args)
        {
            using (System.Threading.Mutex mutex = new System.Threading.Mutex(true, "MyApp.SingleInstance.Mutex", out createdNew))
            {
                MainForm = new MainDlg();
                SingleInstanceApplication.Run(MainForm, StartupNextInstanceEventHandler);
            }
        }
        public static void StartupNextInstanceEventHandler(object sender, StartupNextInstanceEventArgs e)
        {
            MainForm.Activate();
        }
    public class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        private SingleInstanceApplication()
        {
            base.IsSingleInstance = true;
        }
        public static void Run(Form f, StartupNextInstanceEventHandler startupHandler)
        {
            SingleInstanceApplication app = new SingleInstanceApplication();
            app.MainForm = f;
            app.StartupNextInstance += startupHandler;
            app.Run(Environment.GetCommandLineArgs());
        }
    }

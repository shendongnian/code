    public partial class App : Application
    {
        private Mutex _mutex;
        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";
    
        protected override void OnStartup(StartupEventArgs e)
        {
            bool createdNew;
            _mutex = new Mutex(true, "Global\\" + appGuid, out createdNew);
            if (!createdNew)
            {
                _mutex = null;
                MessageBox.Show("Instance already running");
                Application.Current.Shutdown(); // close application!
                return;
            }
    
            base.OnStartup(e);
            //run application code
        }
    
        protected override void OnExit(ExitEventArgs e)
        {          
            if(_mutex != null)
                _mutex.ReleaseMutex();
            base.OnExit(e);
        }
    }

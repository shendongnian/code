    public partial class App : Application
        {
            private Mutex _instanceMutex = null;
    
            protected override void OnStartup(StartupEventArgs e)
            {
    
                string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", ".");
    
                // check that there is only one instance of the control panel running...
                bool createdNew;
                _instanceMutex = new Mutex(true, path, out createdNew);
                if (!createdNew)
                {
                    _instanceMutex = null;
                    MessageBox.Show("Instance already running");
                    Application.Current.Shutdown();
                    return;
                }
    
                base.OnStartup(e);
            }
    
            protected override void OnExit(ExitEventArgs e)
            {
                if (_instanceMutex != null)
                    _instanceMutex.ReleaseMutex();
                base.OnExit(e);
            }
       
    }

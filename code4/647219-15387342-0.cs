    public partial class App : Application
    {
        private Mutex instanceMutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            Boolean createdNew;
            this.instanceMutex = new Mutex(true, "MyApplication", out createdNew);
            if (!createdNew)
            {
                this.instanceMutex = null;
                Application.Current.Shutdown();
                return;
            }
            
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            if (this.instanceMutex != null)
            {
                this.instanceMutex.ReleaseMutex();
            }
            base.OnExit(e);
        }
    }

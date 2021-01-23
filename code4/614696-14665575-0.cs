    public partial class App : Application
    {
        Semaphore sema;
        bool shouldRelease = false;
        protected override void OnStartup(StartupEventArgs e)
        {
            
            bool result = Semaphore.TryOpenExisting("SingleInstanceWPFApp", out sema);
            if (result) // we have another instance running
            {
                App.Current.Shutdown();
            }
            else
            {
                try
                {
                    sema = new Semaphore(1, 1, "SingleInstanceWPFApp");
                }
                catch
                {
                    App.Current.Shutdown(); //
                }
            }
            if (!sema.WaitOne(0))
            {
                App.Current.Shutdown();
            }
            else
            {
                shouldRelease = true;
            }
            
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            if (sema != null && shouldRelease)
            {
                sema.Release();
            }
        }
    }
